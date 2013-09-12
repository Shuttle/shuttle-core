using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class DatabaseGateway : IDatabaseGateway
	{
		private readonly IDatabaseConnectionFactory databaseConnectionFactory;

		private readonly ILog log;

		public static IDatabaseGateway Default()
		{
			return new DatabaseGateway(DatabaseConnectionFactory.Default());
		}

		public DatabaseGateway(IDatabaseConnectionFactory databaseConnectionFactory)
		{
			Guard.AgainstNull(databaseConnectionFactory, "databaseConnectionFactory");

			this.databaseConnectionFactory = databaseConnectionFactory;

			log = Log.For(this);
		}

		private DataTable GetDataTableFor(DataSource source, IExecutableQuery executableQuery)
		{
			var connection = databaseConnectionFactory.Get(source);

			if (connection == null)
			{
				throw new NullReferenceException("There is no open connection.");
			}

			try
			{
				using (var command = connection.CreateCommandToExecute(executableQuery))
				{
					if (Log.IsTraceEnabled)
					{
						Trace(command);
					}

					using (var reader = command.ExecuteReader())
					{
						var results = new DataTable();
						results.Load(reader);
						return results;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(string.Format(@"{0}\r\n\SQL: {1}", ex, executableQuery.Build()));

				throw;
			}
		}

		private void Trace(IDbCommand command)
		{
			var parameters = new StringBuilder();

			foreach (IDataParameter parameter in command.Parameters)
			{
				parameters.AppendFormat(" / {0} = {1}", parameter.ParameterName, parameter.Value);
			}

			log.Trace(string.Format("{0} {1}", command.CommandText, parameters));
		}

		private IEnumerable<DataRow> GetRowsUsing(DataSource source, IExecutableQuery executableQuery)
		{
			return GetDataTableFor(source, executableQuery).Rows.Cast<DataRow>();
		}

		private DataRow GetSingleRowUsing(DataSource source, IExecutableQuery executableQuery)
		{
			var table = GetDataTableFor(source, executableQuery);

			if ((table == null) || (table.Rows.Count == 0))
			{
				return null;
			}

			return table.Rows[0];
		}

		private IDataReader GetReaderUsing(DataSource source, IExecutableQuery executableQuery)
		{
			using (var command = databaseConnectionFactory.Get(source).CreateCommandToExecute(executableQuery))
			{
				if (Log.IsTraceEnabled)
				{
					Trace(command);
				}

				return command.ExecuteReader();
			}
		}

		private int ExecuteUsing(DataSource source, IExecutableQuery executableQuery)
		{
			using (var command = databaseConnectionFactory.Get(source).CreateCommandToExecute(executableQuery))
			{
				if (Log.IsTraceEnabled)
				{
					Trace(command);
				}

				return command.ExecuteNonQuery();
			}
		}

		private T GetScalarUsing<T>(DataSource source, IExecutableQuery executableQuery)
		{
			using (var command = databaseConnectionFactory.Get(source).CreateCommandToExecute(executableQuery))
			{
				if (Log.IsTraceEnabled)
				{
					Trace(command);
				}

				var scalar = command.ExecuteScalar();

				return (scalar != null && scalar != DBNull.Value) ? (T)scalar : default(T);
			}
		}

		public IDataReader GetReaderUsing(DataSource source, IQuery query)
		{
			return GetReaderUsing(source, source.GetExecutableQuery(query));
		}

		public int ExecuteUsing(DataSource source, IQuery query)
		{
			return ExecuteUsing(source, source.GetExecutableQuery(query));
		}

		public T GetScalarUsing<T>(DataSource source, IQuery query)
		{
			return GetScalarUsing<T>(source, source.GetExecutableQuery(query));
		}

		public DataTable GetDataTableFor(DataSource source, IQuery query)
		{
			return GetDataTableFor(source, source.GetExecutableQuery(query));
		}

		public IEnumerable<DataRow> GetRowsUsing(DataSource source, IQuery query)
		{
			return GetRowsUsing(source, source.GetExecutableQuery(query));
		}

		public DataRow GetSingleRowUsing(DataSource source, IQuery query)
		{
			return GetSingleRowUsing(source, source.GetExecutableQuery(query));
		}
	}
}