using System.Collections.Generic;
using System.Data;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class RawQuery : IExecutableQuery
	{
		private const string QUERY_TYPE = "RAW";

		private readonly Dictionary<MappedColumn, object> parameterValues;
		private readonly string sql;

		public RawQuery(string sql)
		{
			this.sql = sql;
			parameterValues = new Dictionary<MappedColumn, object>();
		}

		public void Prepare(DataSource source, IDbCommand command)
		{
			Guard.AgainstNull(source, "source");
			Guard.AgainstNull(command, "command");

			command.CommandText = sql;
			command.CommandType = CommandType.Text;

			foreach (var pair in parameterValues)
			{
				command.Parameters.Add(pair.Key.CreateDataParameter(source.DbDataParameterFactory, pair.Value));
			}
		}

		public string Build()
		{
			return sql;
		}

		public IExecutableQuery AddParameterValue(MappedColumn column, object value)
		{
			parameterValues.Add(column, value);

			return this;
		}

		public static IExecutableQuery CreateFrom(string sql)
		{
			return new RawQuery(sql);
		}

		public static IExecutableQuery CreateFrom(string sql, params string[] args)
		{
			return new RawQuery(string.Format(sql, args));
		}

		public string QueryType
		{
			get { return QUERY_TYPE; }
		}
	}
}