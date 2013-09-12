using System.Data;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class DbCommandFactory : IDbCommandFactory
    {
		private static readonly int commandTimeout = ConfigurationItem<int>.ReadSetting("Shuttle.Core.Data.DbCommandFactory.CommandTimeout", 120).GetValue();

        public IDbCommand CreateCommandUsing(DataSource source, IDbConnection connection, IExecutableQuery executableQuery)
        {
            var command = connection.CreateCommand();

        	command.CommandTimeout = commandTimeout;
            executableQuery.Prepare(source, command);

            return command;
        }
    }
}