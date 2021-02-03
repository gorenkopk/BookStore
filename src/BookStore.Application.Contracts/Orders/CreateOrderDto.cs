using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Orders
{
    public class CreateOrderDto
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public OrderStage Stage { get; set; }
        public float TotalPrice { get; set; }
    }
}
