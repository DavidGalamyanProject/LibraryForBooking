using FluentScheduler;

namespace ShopWebApi.Domain.Job
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<JobReserv>().ToRunNow().AndEvery(3).Seconds();
        }
    }
}
