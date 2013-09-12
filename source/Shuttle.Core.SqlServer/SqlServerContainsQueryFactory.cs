using System;
using System.Linq;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class SqlServerContainsQueryFactory : IQueryFactory
    {
		public bool IsSatisfiedBy(QueryDefinition item)
		{
			Guard.AgainstNull(item, "item");

			return item.QueryType.Equals(ContainsBuilder.QueryType);
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
						"if exists (select null from {0}{1}) select 1 else select 0",
						definition.Table,
						SqlServerWhereBuilder.Instance.Build(whereClauseExpressions)));

			SqlServerWhereBuilder.Instance.AddParameterValues(result, whereClauseExpressions);

			return result;
		}

    	public string QueryType
    	{
			get { return ContainsBuilder.QueryType; }
    	}
    }
}
