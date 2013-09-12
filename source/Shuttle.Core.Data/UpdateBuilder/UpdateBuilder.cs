using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class UpdateBuilder :
		QueryBuilder,
		IUpdateBuilderLogical,
		IUpdateBuilderUpdate,
		IUpdateBuilderWhere
	{
		private MappedColumn builderMappedColumn;
		public static string QueryType = "UPDATE";

		private UpdateBuilder() : base(QueryType)
		{
		}

		public IUpdateBuilderUpdate Set(MappedColumn column)
		{
			builderMappedColumn = column;

			return this;
		}

		public IWhereExpressionBuilder<IUpdateBuilderLogical> And(MappedColumn column)
		{
			return new WhereExpressionBuilder<UpdateBuilder, IUpdateBuilderLogical>(this, column, "and");
		}

		public IWhereExpressionBuilder<IUpdateBuilderLogical> Or(MappedColumn column)
		{
			return new WhereExpressionBuilder<UpdateBuilder, IUpdateBuilderLogical>(this, column, "or");
		}

		public IWhereExpressionBuilder<IUpdateBuilderLogical> Where(MappedColumn column)
		{
			return new WhereExpressionBuilder<UpdateBuilder, IUpdateBuilderLogical>(this, column, "where");
		}

		public IUpdateBuilder ToValue<T>(T value)
		{
			QueryDefinition.AddColumnValue(builderMappedColumn, value);

			return this;
		}

		public static IUpdateBuilder Update()
		{
			return new UpdateBuilder();
		}

		public QueryDefinition In(string table)
		{
			Guard.AgainstNullOrEmptyString(table, "table");

			QueryDefinition.Table = table;

			return QueryDefinition;
		}
	}
}