using System;
using Volo.Abp.Application.Dtos;

namespace BookStore.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public Guid AppUserId { get; set; }
        public OrderStage Stage { get; set; }
        public float TotalPrice { get; set; }
    }
}
