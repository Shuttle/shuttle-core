using System;
using System.Linq;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class SqlServerDeleteQueryFactory : IQueryFactory
    {
		public bool IsSatisfiedBy(QueryDefinition item)
		{
			Guard.AgainstNull(item, "item");

			return item.QueryType.Equals(DeleteBuilder.QueryType);
		}

		public IExecutableQuery Create(QueryDefinition definition)
    	{
			Guard.AgainstNull(definition, "definition");

    		var whereClauseExpressions = definition.WhereClauseExpressions;

    		if (whereClauseExpressions.Count() == 0)
			{
				throw new InvalidOperationException(SqlServerResources.CannotBuildQueryWithNoColumns);
			}

			var result =
				RawQuery.CreateFrom(
					string.Format(
						"delete from [{0}]{1}",
						definition.Table,
						SqlServerWhereBuilder.Instance.Build(whereClauseExpressions)));

			SqlServerWhereBuilder.Instance.AddParameterValues(result, whereClauseExpressions);

			return result;
		}

    	public string QueryType
    	{
			get { return DeleteBuilder.QueryType; }
    	}
    }
}
