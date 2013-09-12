using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class ContainsBuilder : QueryBuilder, IContainsBuilderLogical
	{
		public static string QueryType = "CONTAINS";

		private ContainsBuilder()
			: base(QueryType)
		{
		}

		public MappedColumn builderColumn;

		public IWhereExpressionBuilder<IContainsBuilderLogical> And(MappedColumn column)
		{
			return new WhereExpressionBuilder<ContainsBuilder, IContainsBuilderLogical>(this, column, "and");
		}

		public IWhereExpressionBuilder<IContainsBuilderLogical> Or(MappedColumn column)
		{
			return new WhereExpressionBuilder<ContainsBuilder, IContainsBuilderLogical>(this, column, "or");
		}

		public static IWhereExpressionBuilder<IContainsBuilderLogical> Where(MappedColumn column)
		{
			return new WhereExpressionBuilder<ContainsBuilder, IContainsBuilderLogical>(new ContainsBuilder(), column, "where");
		}

		public QueryDefinition In(string table)
		{
			Guard.AgainstNullOrEmptyString(table, "table");

			QueryDefinition.Table = table;

			return QueryDefinition;
		}
	}
}