using System;
using System.Linq;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class SqlServerSelectQueryFactory : IQueryFactory
	{
		public bool IsSatisfiedBy(QueryDefinition item)
		{
			Guard.AgainstNull(item, "item");

			return item.QueryType.Equals(SelectBuilder.QueryType);
		}

		private static string BuildSelectClause(QueryDefinition definition)
		{
			var selectColumns = definition.SelectColumns;

			var result = new StringBuilder(selectColumns.Count()*16);

			foreach (var column in selectColumns)
			{
				result.AppendFormat("{0} {1}", result.Length > 0 ? "," : string.Empty, column.ColumnName);
			}

			return result.ToString();
		}

		private static string BuildOrderByClause(QueryDefinition definition)
		{
			Guard.AgainstNull(definition, "definition");

			var orderByItems = definition.OrderByItems;
			var count = orderByItems.Count();

			if (count == 0)
			{
				return string.Empty;
			}

			var result = new StringBuilder(count*16);

			foreach (var item in orderByItems)
			{
				result.AppendFormat("{0} {1} {2}", (result.Length == 0 ? " order by" : ","),
				                    item.Column.ColumnName,
				                    item.SortOrder == OrderByItem.SortOrderType.Ascending ? "asc" : "desc");
			}

			return result.ToString();
		}

		public IExecutableQuery Create(QueryDefinition definition)
		{
			if (definition.SelectColumns.Count() == 0)
			{
				throw new InvalidOperationException(SqlServerResources.CannotBuildQueryWithNoColumns);
			}

			var whereClauseExpressions = definition.WhereClauseExpressions;

			var result =
				RawQuery.CreateFrom(
					string.Format(
						"select{0}{1} from {2}{3}{4}",
						definition.LimitTo.HasValue ? string.Format(" top {0}", definition.LimitTo.Value) : string.Empty,
						BuildSelectClause(definition),
						definition.Table,
						SqlServerWhereBuilder.Instance.Build(whereClauseExpressions),
						BuildOrderByClause(definition)));

			SqlServerWhereBuilder.Instance.AddParameterValues(result, whereClauseExpressions);

			return result;
		}

		public string QueryType
		{
			get { return SelectBuilder.QueryType; }
		}
	}
}