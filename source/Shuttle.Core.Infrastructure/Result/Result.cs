using System;
using System.Collections.Generic;
using System.Text;

namespace Shuttle.Core.Infrastructure
{
    public class Result : IResult
    {
        protected static IMapper<string, ResultMessage> mapper = new StringToResultMessageMapper();

        public List<ResultMessage> SuccessMessages { get; private set; }
        public List<ResultMessage> FailureMessages { get; private set; }

        public Result()
        {
            FailureMessages = new List<ResultMessage>();
            SuccessMessages = new List<ResultMessage>();

            Aborted = false;
        }

        public static IResult Create()
        {
            return new Result();
        }

        public bool OK
        {
            get { return FailureMessages.Count == 0; }
        }

        public bool Aborted { get; private set; }

        public void SetAbort()
        {
            Aborted = true;
        }

        public void Merge(IResult result)
        {
            SuccessMessages.AddRange(result.SuccessMessages);
            FailureMessages.AddRange(result.FailureMessages);

            if (result.Aborted)
            {
                SetAbort();
            }
        }

        public bool HasMessages
        {
            get { return HasFailureMessages || HasSuccessMessages; }
        }

        public bool HasFailureMessages
        {
            get { return FailureMessages.Count > 0; }
        }

        public bool HasSuccessMessages
        {
            get { return SuccessMessages.Count > 0; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (HasFailureMessages)
            {
                result.AppendLine("Failure Messages:");

                AppendMessages(result, FailureMessages);
            }

            if (HasSuccessMessages)
            {
                result.AppendLine("Success Messages:");

                AppendMessages(result, SuccessMessages);
            }

            return result.ToString();
        }

        private static void AppendMessages(StringBuilder result, IEnumerable<ResultMessage> messages)
        {
            AppendMessages(0, result, messages);
        }

        private static void AppendMessages(int indent, StringBuilder result, IEnumerable<ResultMessage> messages)
        {
            foreach (var message in messages)
            {
                result.AppendFormat("{0} - {1}", new String(' ', indent * 3), message);
                result.AppendLine();

                AppendMessages(indent + 1, result, message.Messages);
            }
        }

        public void AddFailureMessage(ResultMessage message)
        {
            FailureMessages.Add(message);
        }

        public void AddFailureMessage(string message)
        {
            AddFailureMessages(message);
        }

        public void AddFailureMessages(params string[] messages)
        {
            AddFailureMessages((IEnumerable<string>)messages);
        }

        public void AddFailureMessages(IEnumerable<string> messages)
        {
            FailureMessages.AddRange(messages.MapAllUsing(mapper));
        }

        public void AddSuccessMessage(ResultMessage message)
        {
            SuccessMessages.Add(message);
        }

        public void AddSuccessMessage(string message)
        {
            AddSuccessMessages(message);
        }

        public void AddSuccessMessages(params string[] messages)
        {
            AddSuccessMessages((IEnumerable<string>)messages);
        }

        public void AddSuccessMessages(IEnumerable<string> messages)
        {
            SuccessMessages.AddRange(messages.MapAllUsing(mapper));
        }

        public void AddException(Exception ex)
        {
            AddFailureMessages(ex.Messages());
        }
    }

     public class Result<TValue> : Result, IResult<TValue>
     {
         public Result(TValue value)
         {
             Value = value;
         }

         public IResult<TValue> Create(TValue value)
         {
             return new Result<TValue>(default(TValue));
         }

         public TValue Value { get; private set; }
     }
 }
