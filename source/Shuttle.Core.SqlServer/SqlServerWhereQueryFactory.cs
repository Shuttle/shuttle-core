using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuttle.Core.Data
{
	internal class SqlServerWhereBuilder
	{
		public static SqlServerWhereBuilder Instance = new SqlServerWhereBuilder();

		public string Build(IEnumerable<IWhereExpression> expressions)
		{
			var count = expressions.Count();

			if (count == 0)
			{
				return string.Empty;
			}

			var result = new StringBuilder(count*32);

			foreach (var expression in expressions)
			{
				result.Append(string.Format(" {0} {1} {2} @WHERE_{3}",
				                            expression.LogicalOperator,
				                            expression.Column.ColumnName,
				                            expression.Operator,
				                            expression.Column.FlattenedColumnName()));
			}

			return result.ToString();
		}

		public void AddParameterValues(IExecutableQuery query, IEnumerable<IWhereExpression> whereClauseExpressions)
		{
			foreach (var expression in whereClauseExpressions.Where(expression => expression.HasValue))
			{
				query.AddParameterValue(expression.Column.Rename(string.Format("WHERE_{0}", expression.Column.ColumnName)), expression.Value);
			}
		}
	}
}