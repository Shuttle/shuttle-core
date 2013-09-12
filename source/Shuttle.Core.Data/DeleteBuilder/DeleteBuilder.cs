using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class DeleteBuilder : QueryBuilder, IDeleteBuilderLogical
	{
		public const string QueryType = "DELETE";

		public MappedColumn builderColumn;

		private DeleteBuilder() : base(QueryType)
		{
		}

		public IWhereExpressionBuilder<IDeleteBuilderLogical> And(MappedColumn column)
		{
			return new WhereExpressionBuilder<DeleteBuilder, IDeleteBuilderLogical>(this, column, "and");
		}

		public IWhereExpressionBuilder<IDeleteBuilderLogical> Or(MappedColumn column)
		{
			return new WhereExpressionBuilder<DeleteBuilder, IDeleteBuilderLogical>(this, column, "or");
		}

		public static IWhereExpressionBuilder<IDeleteBuilderLogical> Where(MappedColumn column)
		{
			return new WhereExpressionBuilder<DeleteBuilder, IDeleteBuilderLogical>(new DeleteBuilder(), column, "where");
		}

		public QueryDefinition From(string table)
		{
			Guard.AgainstNullOrEmptyString(table, "table");

			QueryDefinition.Table = table;

			return QueryDefinition;
		}
	}
}