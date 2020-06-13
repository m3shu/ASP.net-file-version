using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ASP.net_file_version.Services
{
    public static class JavascriptExtension
    {
        public static MvcHtmlString IncludeVersionedJs(this HtmlHelper helper, string filename)
        { 
            string version = GetVersion(helper, filename);
            if (filename.Split('.').Last().ToLower() == "css")
                return MvcHtmlString.Create("<link href='" + filename + version + "' rel='stylesheet'></link>");
            return MvcHtmlString.Create("<script src='" + filename + version + "'></script>");
        }

        private static string GetVersion(this HtmlHelper helper, string filename)
        {
            var context = helper.ViewContext.RequestContext.HttpContext;

            if (context.Cache[filename] == null)
            {
                var physicalPath = context.Server.MapPath(filename);
                var version = $"?v={new System.IO.FileInfo(physicalPath).LastWriteTime:MMddHHmmss}";
                context.Cache.Add(filename, version, null, DateTime.Now.AddSeconds(300), TimeSpan.Zero, CacheItemPriority.Normal, null);
                return version;
            }
            else
            {
                return context.Cache[filename] as string;
            }
        }
    }
}