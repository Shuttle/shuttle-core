using System;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Shuttle.Core.Infrastructure.Log4Net
{
	public class ActionAppender : AppenderSkeleton
	{
		private readonly Action<LoggingEvent> action;

		public static void Register(Action<LoggingEvent> action)
		{
			Guard.AgainstNull(action, "action");

			Log.Trace(string.Format("Registering ActionAppender against action '{0}'.", action.GetType().FullName));

			((Hierarchy)LogManager.GetRepository()).Root.AddAppender(new ActionAppender(action));
		}

		public ActionAppender(Action<LoggingEvent> action)
		{
			Guard.AgainstNull(action, "action");

			this.action = action;
		}

		protected override void Append(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				return;
			}

			action.Invoke(loggingEvent);
		}
	}
}