using System;
using System.IO;
using System.Web;

namespace CompanyName.ProductName.Mvc.Common
{
    public class WebUtils
    {
        private static string applicationPath = null;
        private static string applicationPhysicalPath = null;

        /// <summary>
        /// 返回当前Web应用程序的根虚拟目录，结尾不带斜杠/。
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                if (applicationPath == null)
                {
                    applicationPath = VirtualPathUtility.ToAbsolute("~").TrimEnd('/');
                }
                return applicationPath;
            }
        }

        /// <summary>
        /// 返回当前Web应用程序的根物理目录，结尾不带斜杠\。
        /// </summary>
        public static string ApplicationPhysicalPath
        {
            get
            {
                if (applicationPhysicalPath == null)
                {
                    applicationPhysicalPath = AppDomain.CurrentDomain.BaseDirectory.Replace("/", Path.DirectorySeparatorChar.ToString()).TrimEnd(Path.DirectorySeparatorChar);
                }
                return applicationPhysicalPath;
            }
        }

        /// <summary>
        /// 将虚拟目录映射为物理目录。
        /// </summary>
        public static string MapPath(string virtualPath)
        {
            return string.Concat
            (
                ApplicationPhysicalPath.TrimEnd(Path.DirectorySeparatorChar),
                Path.DirectorySeparatorChar.ToString(),
                virtualPath.Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("~", "").TrimStart(Path.DirectorySeparatorChar)
            );
        }

        public static void Return404(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.SuppressContent = true;
            context.Response.End();
        }

        public static string HtmlEncode(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace("&", "&amp;");
                text = text.Replace("<", "&lt;");
                text = text.Replace(">", "&gt;");
                text = text.Replace(" ", "&nbsp;");
                text = text.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
                text = text.Replace("'", "&#39;");
                text = text.Replace("\"", "&quot;");
                text = text.Replace(Environment.NewLine, "<br>");
                text = text.Replace("\n", "<br>");
            }
            return text;
        }

        public static string UrlEncode(string urlToEncode)
        {
            if (string.IsNullOrEmpty(urlToEncode))
            {
                return urlToEncode;
            }
            return HttpUtility.UrlEncode(urlToEncode).Replace("'", "%27");
        }
        public static string UrlDecode(string urlToDecode)
        {
            if (string.IsNullOrEmpty(urlToDecode))
            {
                return urlToDecode;
            }
            return HttpUtility.UrlDecode(urlToDecode);
        }

        public static void SetClientCache(HttpResponse response, TimeSpan expiresDate)
        {
            SetClientCache(response, expiresDate, null);
        }
        public static void SetClientCache(HttpResponse response, TimeSpan expiresDate, DateTime? lastModifiedDate)
        {
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.Cache.SetExpires(DateTime.Now.Add(expiresDate));
            response.Cache.SetMaxAge(expiresDate);
            response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
            if (lastModifiedDate != null)
            {
                response.Cache.SetLastModified(lastModifiedDate.Value);
            }
        }
    }
}
