using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public static class DataRowExtensions
	{
		public static List<T> ToList<T>(this IEnumerable<DataRow> rows, Func<DataRow, T> func)
		{
			Guard.AgainstNull(rows, "rows");
			Guard.AgainstNull(func, "func");

			return rows.Select(func.Invoke).ToList();
		}

		public static bool HasRows(this DataTable table)
		{
			Guard.AgainstNull(table, "table");

			return table.Rows.Count > 0;
		}

		public static DataRow Row(this DataTable table)
		{
			Guard.AgainstNull(table, "table");

			return table.Rows.Count == 0 ? null : table.Rows[0];
		}
	}
}