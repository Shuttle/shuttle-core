using System.Collections.Generic;
using System.Data;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class ProcedureQuery : IExecutableQuery
    {
    	private const string QUERY_TYPE = "PROCEDURE";

        private readonly Dictionary<MappedColumn, object> parameterValues;
        private readonly string procedure;

        public ProcedureQuery(string procedure)
        {
            this.procedure = procedure;
            parameterValues = new Dictionary<MappedColumn, object>();
        }

        public void Prepare(DataSource source, IDbCommand command)
        {
			Guard.AgainstNull(source, "source");
            Guard.AgainstNull(command, "command");

            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var pair in parameterValues)
            {
                command.Parameters.Add(pair.Key.CreateDataParameter(source.DbDataParameterFactory, pair.Value));
            }
        }

        public string Build()
        {
            var result = new StringBuilder(procedure);

            foreach (var pair in parameterValues)
            {
                result.AppendFormat(" @{0}={1}", pair.Key, pair.Value);
            }

            return result.ToString();
        }

        public IExecutableQuery AddParameterValue(MappedColumn column, object value)
        {
            parameterValues.Add(column, value);

            return this;
        }

        public static IExecutableQuery CreateFor(string procedure)
        {
            return new ProcedureQuery(procedure);
        }

    	public string QueryType
    	{
    		get { return QUERY_TYPE; }
    	}
    }
}