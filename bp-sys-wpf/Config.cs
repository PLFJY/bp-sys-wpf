using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Flurl.Http;
using Flurl;

namespace bp_sys_wpf
{
    public static class Config
    {
        public static string BackEnd_Url { get; set; }="https://api.idvasg.cn/";
        public static string version { get; set; } = "2.2.3";
    }
}
