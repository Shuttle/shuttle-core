namespace Shuttle.Core.Infrastructure
{
	public class RegexPatterns
	{
		public static string StartsWith(string startsWith)
		{
			return string.Format(@"\A{0}.*", startsWith);
		}

		public static string EndsWith(string endsWith)
		{
			return string.Format(@".*{0}\Z", endsWith);
		}
	}
}