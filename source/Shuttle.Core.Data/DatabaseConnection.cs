using System;
using System.Data;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly DataSource source;
        private readonly IDbCommandFactory dbCommandFactory;
        private readonly IDatabaseConnectionCache databaseConnectionCache;
        private readonly ILog log;

        private bool disposed;

        public DatabaseConnection(DataSource source, IDbConnectionFactory dbConnectionFactory, IDbCommandFactory dbCommandFactory, IDatabaseConnectionCache databaseConnectionCache)
        {
            this.source = source;
            this.dbCommandFactory = dbCommandFactory;
            this.databaseConnectionCache = databaseConnectionCache;

            Connection = dbConnectionFactory.CreateConnection(source);

            log = Log.For(this);

            log.Verbose(string.Format(DataResources.DbConnectionCreated, source.Name));

            try
            {
                Connection.Open();

                log.Verbose(string.Format(DataResources.DbConnectionOpened, source.Name));
            }
            catch (Exception ex)
            {
                log.Error(string.Format(DataResources.DbConnectionOpenException, source.Name, ex.CompactMessages()));

                throw;
            }

            databaseConnectionCache.Add(source, this);
        }

        public IDbCommand CreateCommandToExecute(IExecutableQuery executableQuery)
        {
            var command = dbCommandFactory.CreateCommandUsing(source, Connection, executableQuery);
            command.Transaction = Transaction;
            return command;
        }

        public bool HasTransaction
        {
            get { return Transaction != null; }
        }

        public IDbTransaction Transaction { get; private set; }
        public IDbConnection Connection { get; private set; }

        public IDatabaseConnection BeginTransaction()
        {
            if (!HasTransaction && System.Transactions.Transaction.Current == null)
            {
                Transaction = Connection.BeginTransaction();
            }

            return this;
        }

        public void CommitTransaction()
        {
            if (!HasTransaction)
            {
                return;
            }

            Transaction.Commit();
            Transaction = null;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (HasTransaction)
                {
                    Transaction.Rollback();
                }
                Connection.Dispose();
                databaseConnectionCache.Remove(source);
            }

            Connection = null;
            disposed = true;
        }
    }
}