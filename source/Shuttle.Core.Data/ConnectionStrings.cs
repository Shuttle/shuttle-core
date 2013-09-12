using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
    public static class ConnectionStrings
    {
        public static void Approve()
        {
            foreach (ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                try
                {
                    using (var connection = DbProviderFactories.GetFactory(settings.ProviderName).CreateConnection())
                    {
                        connection.ConnectionString = settings.ConnectionString;
                        connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    var message = string.Format(DataResources.DbConnectionOpenException, settings.Name, ex.CompactMessages());

                    Log.Error(message);

                    throw new DataException(message);
                }
            }
        }
    }
}