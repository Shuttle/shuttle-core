namespace Shuttle.Core.Data
{
    public class WhereExpression : IWhereExpression
    {
        public WhereExpression(string logicalOperator, MappedColumn column, string @operator)
        {
            LogicalOperator = logicalOperator;
            Column = column;
            Operator = @operator;

            Value = null;
        }

        public object Value { get; private set; }

        public bool HasValue
        {
            get { return Value != null; }
        }

        public MappedColumn Column { get; private set; }
        public string Operator { get; private set; }
        public string LogicalOperator { get; private set; }

        public IWhereExpression WithValue(object value)
        {
            Value = value;

            return this;
        }
    }
}