﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZerochSharp.Models.ExtensionLanguage
{
    public abstract class Atomic
    {
        private protected string AtomicString;
        public override string ToString()
        {
            var type = GetType();
            return type.Name.Remove(type.Name.IndexOf("Atomic", StringComparison.Ordinal)) + ": " + AtomicString;
        }
    }
}
