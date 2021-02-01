using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public OrderStage Stage { get; set; }

        public float TotalPrice { get; set; }

    }
}
