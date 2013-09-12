using System;
using System.IO;
using System.Web;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Web
{
    public class CachingModule : IHttpModule
    {
        private static readonly string[] CACHED_FILE_TYPES = new[] { ".css", ".gif", ".ico", ".jpg", ".js", ".png" };
        private static readonly TimeSpan YEAR = TimeSpan.FromDays(365);

    	private readonly ILog log;

    	public CachingModule()
    	{
    		log = Log.For(this);
    	}

    	public void Init(HttpApplication context)
        {
            context.AcquireRequestState += context_AcquireRequestState;
        }

        public void Dispose()
        {
        }

        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            if (context == null || context.Response == null)
            {
                return;
            }

            var fileExtension = Path.GetExtension(context.Request.PhysicalPath).ToLower();

            if (context.Response.Cache == null || Array.BinarySearch(CACHED_FILE_TYPES, fileExtension) < 0)
            {
                return;
            }

            var cache = context.Response.Cache;

            cache.SetCacheability(HttpCacheability.Public);
            cache.SetExpires(DateTime.Now.Add(YEAR));
            cache.SetValidUntilExpires(true);
            cache.SetNoServerCaching();
            cache.SetMaxAge(YEAR);

			log.Verbose(string.Format("[set caching] : {0}", context.Request.PhysicalPath));
        }
    }
}