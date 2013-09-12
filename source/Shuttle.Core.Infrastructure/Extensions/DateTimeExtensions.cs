using System;

namespace Shuttle.Core.Infrastructure
{
    public static class DateTimeExtensions
    {
        public static DateTime MoveTime(this DateTime fromDate, DateTime toDate)
        {
            return DateTime.Parse(toDate.ToString("dd MMM yyyy ") + fromDate.ToString("HH:mm:ss"));
        }

        public static DateTime StripSeconds(this DateTime dateTime)
        {
            return dateTime.Subtract(new TimeSpan(0, 0, dateTime.Second));
        }
        
		/// <summary>
		/// Formats the date as yyyy/MM/ddIQ
		/// </summary>
		/// <param name="date"></param>
		/// <returns>Date formatted as string</returns>
		public static string FormatSimple(this DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }

		/// <summary>
		/// Formats the date as dd MMM yyyy HH:mm:ss
		/// </summary>
		/// <param name="date"></param>
		/// <returns>Formatted date</returns>
		public static string FormatFull(this DateTime date)
        {
            return date.ToString("dd MMM yyyy HH:mm:ss");
        }

		/// <summary>
		/// Determines whether two dates are on the same day.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="other"></param>
		/// <returns>Date formatted as string.</returns>
		public static bool IsSameDay(this DateTime date, DateTime other)
		{
			return (date.Year == other.Year) && (date.Month == other.Month) && (date.Day == other.Day);
		}
    }
}