using System;

namespace Shuttle.Core.Data
{
	public class WhereExpressionBuilder<TBuilder, TLogical> : IWhereExpressionBuilder<TLogical>
		where TBuilder : TLogical, IWhereExpressionContainer
	{
		private readonly TBuilder builder;
		private readonly MappedColumn column;
		private readonly string logicalOperator;

		public WhereExpressionBuilder(TBuilder builder, MappedColumn column, string logicalOperator)
		{
			this.builder = builder;
			this.column = column;
			this.logicalOperator = logicalOperator;
		}

		public TLogical WithLike()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "like"));

			return builder;
		}

		public TLogical WithEqualTo()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "="));

			return builder;
		}

		public TLogical WithNotLike()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "not like"));

			return builder;
		}

		public TLogical WithNotEqualTo()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<>"));

			return builder;
		}

		public TLogical WithGreaterThan()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, ">"));

			return builder;
		}

		public TLogical WithLessThan()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<"));

			return builder;
		}

		public TLogical WithGreaterThanOrEqualTo()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, ">="));

			return builder;
		}

		public TLogical WithLessThanOrEqualTo()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<="));

			return builder;
		}

		public TLogical Like<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "like").WithValue(value));

			return builder;
		}

		public TLogical EqualTo<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "=").WithValue(value));

			return builder;
		}

		public TLogical NotLike<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "not like").WithValue(value));

			return builder;
		}

		public TLogical NotEqualTo<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<>").WithValue(value));

			return builder;
		}

		public TLogical GreaterThan<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, ">").WithValue(value));

			return builder;
		}

		public TLogical LessThan<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<").WithValue(value));

			return builder;
		}

		public TLogical GreaterThanOrEqualTo<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, ">=").WithValue(value));

			return builder;
		}

		public TLogical LessThanOrEqualTo<TValue>(TValue value)
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "<=").WithValue(value));

			return builder;
		}

		public TLogical Null()
		{
			builder.AddWhereExpression(new WhereExpression(logicalOperator, column, "=").WithValue(DBNull.Value));

			return builder;
		}
	}
}