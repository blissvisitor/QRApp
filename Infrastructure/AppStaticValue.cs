using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Infrastructure
{
    public static class AppStaticValue
    {
        public static string SiteUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteUrl"];
            }
        }
    }
}
