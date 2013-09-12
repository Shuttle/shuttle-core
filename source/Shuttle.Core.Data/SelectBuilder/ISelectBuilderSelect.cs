namespace Shuttle.Core.Data
{
    public interface ISelectBuilderSelect : ISelectBuilderWhere
    {
        ISelectBuilderSelect With(MappedColumn column);
    }
}