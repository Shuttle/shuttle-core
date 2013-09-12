using System.Collections.Generic;

namespace Shuttle.Core.Data
{
	public abstract class QueryBuilder : IWhereExpressionContainer
	{
		protected QueryBuilder(string identifier)
		{
			QueryDefinition = new QueryDefinition(identifier);
		}

		public QueryDefinition QueryDefinition { get; private set; }
		
		public void AddWhereExpression(IWhereExpression expression)
		{
			QueryDefinition.AddWhereExpression(expression);
		}

		public IEnumerable<IWhereExpression> WhereClauseExpressions
		{
			get { return QueryDefinition.WhereClauseExpressions; }
		}
	}
}