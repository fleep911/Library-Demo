using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AmTrustDemo.Models
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}