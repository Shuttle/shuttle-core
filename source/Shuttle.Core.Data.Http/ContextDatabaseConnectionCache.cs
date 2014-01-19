using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data.Http
{
	public class ContextDatabaseConnectionCache : IDatabaseConnectionCache
	{
		[ThreadStatic]
		private static Dictionary<string, IDatabaseConnection> connections;

		private static IDictionary Items
		{
			get
			{
				return OperationContext.Current == null && HttpContext.Current == null
					       ? (connections ?? (connections = new Dictionary<string, IDatabaseConnection>()))
					       : (OperationContext.Current != null
						          ? ItemOperationContext.Current.Items
						          : HttpContext.Current.Items);
			}
		}

		private static string Key(DataSource source)
		{
			return string.Format("connection-{0}", source.Key);
		}

		public IDatabaseConnection Get(DataSource source)
		{
			var key = Key(source);

			if (Items[key] == null)
			{
				throw new ApplicationException(
					string.Format("Attempt to retrieve non-existent connection name '{0}' from ContextDatabaseConnectionCache.",
								  source.Name));
			}

			return (IDatabaseConnection)Items[key];
		}

		public IDatabaseConnection Add(DataSource source, IDatabaseConnection connection)
		{
			Guard.AgainstNull(connection, "connection");

			var key = Key(source);

			if (Items[key] != null)
			{
				throw new ApplicationException(
					string.Format("Attempt to add duplicate connection name '{0}' to ContextDatabaseConnectionCache.", source.Name));
			}

			Items.Add(key, connection);

			return connection;
		}

		public void Remove(DataSource source)
		{
			var key = Key(source);

			if (Items[key] == null)
			{
				throw new ApplicationException(
					string.Format("Attempt to remove non-existent connection name '{0}' from ContextDatabaseConnectionCache.", source.Name));
			}

			Items.Remove(key);
		}

		public bool Contains(DataSource source)
		{
			return Items[Key(source)] != null;
		}
	}
}