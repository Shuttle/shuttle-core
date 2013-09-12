using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class SqlServerInsertQueryFactory : IQueryFactory
    {
		public bool IsSatisfiedBy(QueryDefinition item)
		{
			Guard.AgainstNull(item, "item");

			return item.QueryType.Equals(InsertBuilder.QueryType);
		}

		private static string BuildValues(IEnumerable<KeyValuePair<MappedColumn, object>> columnValues)
        {
            var result = new StringBuilder();

            foreach (var columnValue in columnValues)
            {
                result.AppendFormat("{0}@{1}", result.Length > 0 ? ", " : string.Empty, columnValue.Key.ColumnName);
            }

            return result.ToString();
        }

        private static string BuildColumns(IEnumerable<KeyValuePair<MappedColumn, object>> columnValues)
        {
            var result = new StringBuilder();

            foreach (var columnValue in columnValues)
            {
                result.AppendFormat("{0}{1}", result.Length > 0 ? ", " : string.Empty, columnValue.Key.ColumnName);
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

			var result =
				RawQuery.CreateFrom(
					string.Format(
						"insert into [{0}] ({1}) values ({2})",
						definition.Table,
						BuildColumns(columnValues),
						BuildValues(columnValues)));

			foreach (var columnValue in columnValues)
			{
				result.AddParameterValue(columnValue.Key, columnValue.Value);
			}

			return result;
		}

    	public string QueryType
    	{
			get { return InsertBuilder.QueryType; }
    	}
    }
}
