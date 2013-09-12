using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class QueryDefinition : IQuery
	{
		public string QueryType { get; private set; }

		private readonly List<IWhereExpression> whereClauseExpressions = new List<IWhereExpression>();
		protected readonly List<MappedColumn> selectColumns = new List<MappedColumn>();
		protected readonly List<IOrderByItem> orderByItems = new List<IOrderByItem>();
		protected readonly Dictionary<MappedColumn, object> columnValues = new Dictionary<MappedColumn, object>();

		public QueryDefinition(string type)
		{
			Guard.AgainstNullOrEmptyString(type, "identifier");

			QueryType = type;
		}

		public void AddWhereExpression(IWhereExpression expression)
		{
			Guard.AgainstNull(expression, "expression");

			whereClauseExpressions.Add(expression);
		}

		public IEnumerable<IWhereExpression> WhereClauseExpressions
		{
			get { return new ReadOnlyCollection<IWhereExpression>(whereClauseExpressions); }
		}

		public string Table { get; set; }

		public IEnumerable<MappedColumn> SelectColumns
		{
			get { return new ReadOnlyCollection<MappedColumn>(selectColumns); }
		}

		public IEnumerable<IOrderByItem> OrderByItems
		{
			get { return new ReadOnlyCollection<IOrderByItem>(orderByItems); }
		}

		public IEnumerable<KeyValuePair<MappedColumn, object>> ColumnValues
		{
			get { return new ReadOnlyDictionary<MappedColumn, object>(columnValues); }
		}

		public int? LimitTo { get; set; }

		public void AddSelectColumn(MappedColumn column)
		{
			Guard.AgainstNull(column, "column");

			selectColumns.Add(column);
		}

		public void AddOrderByItem(IOrderByItem item)
		{
			Guard.AgainstNull(item, "item");

			orderByItems.Add(item);
		}

		public void AddColumnValue(MappedColumn column, object value)
		{
			Guard.AgainstNull(column, "column");

			columnValues.Add(column, value);
		}
	}
}