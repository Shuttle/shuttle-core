using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace Shuttle.Core.Data.Http
{
	public class ItemOperationContext : IExtension<OperationContext>
	{
		private readonly IDictionary items;

		private ItemOperationContext()
		{
			items = new Dictionary<string, object>();
		}

		public IDictionary Items
		{
			get { return items; }
		}

		public static ItemOperationContext Current
		{
			get
			{
				var context = OperationContext.Current.Extensions.Find<ItemOperationContext>();
				if (context == null)
				{
					context = new ItemOperationContext();
					OperationContext.Current.Extensions.Add(context);
				}
				return context;
			}
		}

		public void Attach(OperationContext owner)
		{
		}

		public void Detach(OperationContext owner)
		{
		}
	}
}