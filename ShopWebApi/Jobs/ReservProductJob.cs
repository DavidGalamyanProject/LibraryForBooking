using Quartz;
using ShopWebApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Jobs
{
    public class ReservProductJob : IJob
    {
        private IProductReservationManager _reservationManager;
        public ReservProductJob(IProductReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
