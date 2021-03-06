﻿using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using ZerochSharp.Models.Boards;
using ZerochSharp.Models.Boards.Restrictions;
using ZerochSharp.Models.Caps;

namespace ZerochSharp.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SiteSetting> Setting { get; set; }
        public DbSet<GlobalSetting> GlobalSettings { get; set; }
        public DbSet<NgWord> NgWords { get; set; }
        public DbSet<RestrictedUser> RestrictedUsers { get; set; }
        public DbSet<Cap> Caps { get; set; }
        public DbSet<CapGroup> CapGroups { get; set; }
        public DbSet<CapGroupBoardPair> CapGroupBoards { get; set; }
        public DbSet<CapGroupCapPair> CapGroupCaps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<User>().HasIndex(x => x.UserId).IsUnique(true);
            modelBuilder.Entity<Board>().HasData(new[]
            {
                new Board(){ BoardKey = "news7vip", BoardName = "裏VIP" , Id = 1,BoardDefaultName="以下、名無しにかわりまして裏VIP(´・ω・`)がお送りします" },
                new Board(){ BoardKey = "coffeehouse", BoardName="雑談ルノワール", Id = 2,BoardDefaultName="雑談うんちー" }
            });
            //modelBuilder.Entity<SiteSetting>().HasNoKey();
            modelBuilder.Entity<SiteSetting>().HasData(new[]
            {
                new SiteSetting() { SiteName = "Zeroch Sharp Client",Id = 1 }
            });
            modelBuilder.Entity<GlobalSetting>().HasData(new[]
            {
                new GlobalSetting() { Id = 1, IsInitializedElasticsearchService = false,IsInitialized = false }
            });
        }
        public static DbContextOptionsBuilder InitializeDbBuilder(DbContextOptionsBuilder options, string connectionString, string serverVersion, string serverTypeStr)
        {
            var serverType = (ServerType)Enum.ToObject(typeof(ServerType), int.Parse(serverTypeStr));
            options.UseMySql(connectionString,
                                    mysqlOptions =>
                                    {
                                        mysqlOptions.EnableRetryOnFailure();
                                        mysqlOptions.ServerVersion(new Version(serverVersion), serverType);
                                    });
            return options;
        }
    }
}
