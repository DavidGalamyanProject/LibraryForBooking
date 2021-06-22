using Quartz;
using ShopWebApi.Domain.Interfaces;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Job
{
	/// <summary> Joba, дергается крватзом для регистрации резервов. </summary>
    [DisallowConcurrentExecution]
    public class ReserveJob : IJob
    {
        private readonly IReservationManager _manager;

        public ReserveJob(IReservationManager manager)
        {
            _manager = manager;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _manager.ReservProducts().Wait();
            return Task.CompletedTask;
        }
    }
}

