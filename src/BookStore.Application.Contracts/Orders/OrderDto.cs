using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookStore.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public Guid UserId { get; set; }

        public string UserEmail { get; set; }

        public OrderStage Stage { get; set; }

        public float TotalPrice { get; set; }
    }
}
