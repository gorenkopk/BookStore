using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public OrderStage Stage { get; set; }
        public float TotalPrice { get; set; }
    }
}
