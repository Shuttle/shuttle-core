using System.Threading;

namespace Shuttle.Core.Infrastructure
{
    public static class ThreadSleep
    {
        public static void While(int ms, IActiveState state)
        {
            While(ms, state, 5);
        }

        public static void While(int ms, IActiveState state, int step)
        {
            var elapsed = 0;

            while (state.Active && elapsed < ms)
            {
                Thread.Sleep(step);

                elapsed += step;
            }
        }
    }
}