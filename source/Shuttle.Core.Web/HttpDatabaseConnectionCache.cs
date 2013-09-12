using System;
using System.Web;
using Shuttle.Core.Data;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Web
{
    public class HttpDatabaseConnectionCache : IDatabaseConnectionCache
    {
        private static string SessionKey(DataSource source)
        {
            return string.Format("connection-{0}", source.Key);
        }

        public IDatabaseConnection Get(DataSource source)
        {
            var key = SessionKey(source);

            if (HttpContext.Current.Session[key] == null)
            {
                throw new ApplicationException(string.Format("Attempt to retrieve non-existent connection name '{0}' from HttpDatabaseConnectionCache.", source.Name));
            }

            return (IDatabaseConnection)HttpContext.Current.Session[key];
        }

        public IDatabaseConnection Add(DataSource source, IDatabaseConnection connection)
        {
			Guard.AgainstNull(connection, "connection");

            var key = SessionKey(source);

            if (HttpContext.Current.Session[key] != null)
            {
                throw new ApplicationException(string.Format("Attempt to add duplicate connection name '{0}' to HttpDatabaseConnectionCache.", source.Name));
            }

            HttpContext.Current.Session.Add(key, connection);

        	return connection;
        }

        public void Remove(DataSource source)
        {
            var key = SessionKey(source);

            if (HttpContext.Current.Session[key] == null)
            {
                throw new ApplicationException(string.Format("Attempt to remove non-existent connection name '{0}' from HttpDatabaseConnectionCache.", source.Name));
            }

            HttpContext.Current.Session.Remove(key);
        }

        public bool Contains(DataSource source)
        {
            return HttpContext.Current.Session[SessionKey(source)] != null;
        }
    }
}
