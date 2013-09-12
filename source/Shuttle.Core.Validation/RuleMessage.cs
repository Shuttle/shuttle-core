using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public class RuleMessage
    {
        private readonly List<string> detailMessages = new List<string>();

        public RuleMessage(string message)
        {
            Message = message;
        }

        public string Message { get; internal set; }

        public IEnumerable<string> DetailMessages
        {
            get { return new ReadOnlyCollection<string>(detailMessages); }
        }

        public void AddDetailMessage(string message)
        {
            detailMessages.Add(message);
        }

        public void AddDetailMessages(IEnumerable<string> messages)
        {
            detailMessages.AddRange(messages);
        }

        public void AddDetailMessages(IEnumerable<RuleMessage> messages)
        {
            messages.ForEach(message => detailMessages.Add(message.Message));
        }

		public IEnumerable<string> Flatten()
		{
			var result = new List<string>();

			if (detailMessages.Count == 0)
			{
				result.Add(Message);
			}
			else
			{
				result.AddRange(detailMessages.Select(detailMessage => string.Format("[{0}] : {1}", Message, detailMessage)));
			}

			return result;
		}
    }
}
