using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class SqlServerUpdateQueryFactory : IQueryFactory
    {
		public bool IsSatisfiedBy(QueryDefinition item)
		{
			Guard.AgainstNull(item, "item");

			return item.QueryType.Equals(UpdateBuilder.QueryType);
		}

		private static string BuildUpdateColumns(IEnumerable<KeyValuePair<MappedColumn, object>> columnValues)
        {
            var result = new StringBuilder();

            foreach (var columnValue in columnValues)
            {
                result.AppendFormat("{0}{1} = @{1}", result.Length > 0
                                                         ? ", "
                                                         : string.Empty, columnValue.Key.ColumnName);
            }

            return result.ToString();
        }

    	public IExecutableQuery Create(QueryDefinition definition)
    	{
    		Guard.AgainstNull(definition, "definition");

    		var columnValues = definition.ColumnValues;

    		if (columnValues.Count() == 0)
			{
				throw new InvalidOperationException(SqlServerResources.CannotBuildQueryWithNoColumns);
			}

    		var whereClauseExpressions = definition.WhereClauseExpressions;

    		var result =
				RawQuery.CreateFrom(
					string.Format(
						"update [{0}] set {1} {2}",
						definition.Table,
						BuildUpdateColumns(columnValues),
						SqlServerWhereBuilder.Instance.Build(whereClauseExpressions)));

			SqlServerWhereBuilder.Instance.AddParameterValues(result, whereClauseExpressions);

			foreach (var columnValue in columnValues)
			{
				result.AddParameterValue(columnValue.Key, columnValue.Value);
			}

			return result;
		}

    	public string QueryType
    	{
			get { return UpdateBuilder.QueryType; }
    	}
    }
}
