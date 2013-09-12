using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class InsertBuilder : QueryBuilder, IInsertBuilder, IInsertBuilderAdd
	{
		private MappedColumn builderMappedColumn;

		public static string QueryType = "INSERT";

		private InsertBuilder() : base(QueryType)
		{
		}

		public IInsertBuilderAdd Add(MappedColumn column)
		{
			builderMappedColumn = column;

			return this;
		}

		public QueryDefinition Into(string table)
		{
			Guard.AgainstNullOrEmptyString(table, "table");

			QueryDefinition.Table = table;

			return QueryDefinition;
		}

		public IInsertBuilder WithValue<T>(T value)
		{
			QueryDefinition.AddColumnValue(builderMappedColumn, value);

			return this;
		}

		public static IInsertBuilder Insert()
		{
			return new InsertBuilder();
		}
	}
}