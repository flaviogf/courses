using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            EstimatedDateDelivery = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(estimatedDeliveryDate.Date, DateTime.Today.Date, nameof(EstimatedDateDelivery), "Invalid estimated date delivery"));
        }

        public DateTime EstimatedDateDelivery { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            if (DateOnTime())
            {
                Status = EDeliveryStatus.Shipped;
                return;
            }

            Status = EDeliveryStatus.Canceled;
        }

        public void Cancel()
        {
            if (DoShipped()) return;
            Status = EDeliveryStatus.Canceled;
        }

        private bool DateOnTime()
        {
            return EstimatedDateDelivery >= DateTime.Today.Date;
        }

        private bool DoShipped()
        {
            return Status == EDeliveryStatus.Shipped;
        }
    }
}