using System.Data;

namespace Shuttle.Core.Data
{
    public interface IExecutableQuery : IQuery
	{
        void Prepare(DataSource source, IDbCommand command);
        string Build();
        IExecutableQuery AddParameterValue(MappedColumn column, object value);
    }
}