using System;
using System.IO.Compression;
using System.Web;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Web
{
	public class CompressionModule : IHttpModule
	{
		void IHttpModule.Init(HttpApplication context)
		{
			context.BeginRequest += context_BeginRequest;
		}

		public void Dispose()
		{
		}

		private static void context_BeginRequest(object sender, EventArgs e)
		{
			var app = (HttpApplication)sender;

			var encodings = app.Request.Headers.Get("Accept-Encoding");

			if (encodings == null)
			{
				return;
			}

			var s = app.Response.Filter;

			encodings = encodings.ToLower();

			if (encodings.Contains("gzip"))
			{
				app.Response.Filter = new GZipStream(s, CompressionMode.Compress);
				app.Response.AppendHeader("Content-Encoding", "gzip");

				Log.Verbose(string.Format("[gzip] : {0}", app.Request.PhysicalPath));
			}
			else if (encodings.Contains("deflate"))
			{
				app.Response.Filter = new DeflateStream(s, CompressionMode.Compress);
				app.Response.AppendHeader("Content-Encoding", "deflate");

				Log.Verbose(string.Format("[deflate] : {0}", app.Request.PhysicalPath));
			}
		}
	}
}