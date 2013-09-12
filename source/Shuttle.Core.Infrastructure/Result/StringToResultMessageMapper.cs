namespace Shuttle.Core.Infrastructure
{
    public class StringToResultMessageMapper : IMapper<string, ResultMessage>
    {
        public static StringToResultMessageMapper Instance = new StringToResultMessageMapper();

        public ResultMessage MapFrom(string input)
        {
            return new ResultMessage(input);
        }
    }
}
