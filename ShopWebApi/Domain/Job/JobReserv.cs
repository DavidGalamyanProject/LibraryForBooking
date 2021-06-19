using FluentScheduler;
using ShopWebApi.Domain.Interfaces;

namespace ShopWebApi.Domain.Job
{
    public class JobReserv : IJob
    {
        private readonly IReservationManager _reservationManager;

        public JobReserv(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        public void Execute()
        {
            if(SingletonAccounting.RequestReservQueue == null)
            {
                return;
            }
            _reservationManager.ReservProducts();
        }
    }
}
