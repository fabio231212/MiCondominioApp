using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Utils
{
    public  static class Utilitarios
    {
        public static string GetRoot()
        {
            string serverName = HttpContext.Current.Request.Url.Host;
            string appPath = HttpContext.Current.Request.ApplicationPath;
            int port = HttpContext.Current.Request.Url.Port;
            string baseUrl = string.Format("https://{0}:{1}", serverName, port);
            return baseUrl;
        }
    }
}