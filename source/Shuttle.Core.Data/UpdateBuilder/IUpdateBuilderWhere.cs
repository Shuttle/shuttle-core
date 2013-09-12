namespace Shuttle.Core.Data
{
	public interface IUpdateBuilderWhere
	{
		IWhereExpressionBuilder<IUpdateBuilderLogical> Where(MappedColumn column);
	}
}