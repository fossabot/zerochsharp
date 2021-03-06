﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZerochSharp.Models;
using ZerochSharp.Models.Attributes;
using ZerochSharp.Models.Boards;

namespace ZerochSharp.Controllers.Legacy
{
    [Route("/{boardKey}/SETTING.TXT")]
    [Controller]
    public class LegacySettingTxtController : ControllerBase
    {
        private readonly MainContext _context;

        public LegacySettingTxtController(MainContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        [Produces("text/plain; charset=shift_jis")]
        public async Task<IActionResult> GetSettingTxt([FromRoute] string boardKey)
        {
            var board = await _context.Boards.FirstOrDefaultAsync(x => x.BoardKey == boardKey);
            var sb = new StringBuilder();
            var boardType = typeof(Board);
            var members = boardType.GetProperties();
            foreach (var item in members)
            {
                var attributes = item.GetCustomAttributes(typeof(SettingTxtAttribute));
                foreach (var attribute in attributes)
                {
                    if (attribute is SettingTxtAttribute settingTxtAttr)
                    {
                        sb.AppendLine(settingTxtAttr.Name + "=" + (string)boardType.GetProperty(item.Name)?.GetValue(board));
                    }
                }
            }
            return Ok(sb.ToString());
        }
    }
}
