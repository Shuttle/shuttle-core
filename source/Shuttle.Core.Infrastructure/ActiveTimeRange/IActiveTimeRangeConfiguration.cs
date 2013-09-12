namespace Shuttle.Core.Infrastructure
{
	public interface IActiveTimeRangeConfiguration
	{
		string ActiveFromTime { get; }
		string ActiveToTime { get; }

		ActiveTimeRange CreateActiveTimeRange();
	}
}