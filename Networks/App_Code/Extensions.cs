using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Networks
{
    public static class Extensions
    {
        [DebuggerStepThrough]
        public static string SParam(string value)
        {
            return String.Concat("'", value, "'");
        }
    }
}