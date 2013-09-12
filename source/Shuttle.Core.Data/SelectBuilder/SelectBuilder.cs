using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class SelectBuilder :
		QueryBuilder,
		ISelectBuilderLogical,
		ISelectBuilderOrderByThen,
		ISelectBuilderSelect
	{
		public static string QueryType = "SELECT";

		private SelectBuilder() : base(QueryType)
		{
		}

		internal void AddColumn(MappedColumn column)
		{
			QueryDefinition.AddSelectColumn(column);
		}

		public IWhereExpressionBuilder<ISelectBuilderLogical> Where(MappedColumn column)
		{
			return new WhereExpressionBuilder<SelectBuilder, ISelectBuilderLogical>(this, column, "where");
		}

		ISelectBuilderSelect ISelectBuilderSelect.With(MappedColumn column)
		{
			AddColumn(column);

			return this;
		}

		public IOrderByClauseItem OrderBy(MappedColumn column)
		{
			return new OrderByClauseItem(this, column);
		}

		public IOrderByClauseItem Then(MappedColumn column)
		{
			return new OrderByClauseItem(this, column);
		}

		public QueryDefinition From(string table)
		{
			Guard.AgainstNullOrEmptyString(table, "table");

			QueryDefinition.Table = table;

			return QueryDefinition;
		}

		ISelectBuilderBuild ISelectBuilderBuild.LimitTo(int records)
		{
			QueryDefinition.LimitTo = records;

			return this;
		}

		public IWhereExpressionBuilder<ISelectBuilderLogical> And(MappedColumn column)
		{
			return new WhereExpressionBuilder<SelectBuilder, ISelectBuilderLogical>(this, column, "and");
		}

		public IWhereExpressionBuilder<ISelectBuilderLogical> Or(MappedColumn column)
		{
			return new WhereExpressionBuilder<SelectBuilder, ISelectBuilderLogical>(this, column, "or");
		}

		internal void AddOrderByItem(IOrderByItem item)
		{
			QueryDefinition.AddOrderByItem(item);
		}

		public static ISelectBuilderSelect Select(MappedColumn column)
		{
			var result = new SelectBuilder();

			result.AddColumn(column);

			return result;
		}
	}
}