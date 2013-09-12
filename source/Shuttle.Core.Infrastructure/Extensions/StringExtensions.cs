using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Shuttle.Core.Infrastructure
{
	public static class StringExtensions
	{
		private static readonly Regex guidExpression =
			new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");

		public static string EnsureTrailingBackslash(this string path)
		{
			return !path.EndsWith(@"\") ? path + @"\" : path;
		}

		public static bool IsGuid(this string s)
		{
			return guidExpression.IsMatch(s);
		}

		public static Guid ToGuid(this string s)
		{
			return new Guid(s);
		}

		public static string EscapeXml(this string raw)
		{
			return raw.EscapeXml(Encoding.Default);
		}

		public static string EscapeXml(this string raw, Encoding encoding)
		{
			using (var stream = new MemoryStream())
			{
				using (var writer = new XmlTextWriter(stream, Encoding.Default))
				{
					writer.WriteString(raw);
				}

				return encoding.GetString(stream.ToArray());
			}
		}

		public static string Truncate(this string str, int at)
		{
			return str == null ? null : str.Substring(0, Math.Min(at, str.Length));
		}
	}
}