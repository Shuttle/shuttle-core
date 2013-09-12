namespace Shuttle.Core.Data
{
    public interface ISelectBuilderBuild
    {
        QueryDefinition From(string table);
        ISelectBuilderBuild LimitTo(int records);
    }
}