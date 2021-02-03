using BookStore.Books;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace BookStore.Orders
{
    public class OrderManager : DomainService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<Order> CreateAsync(
            Guid bookId,
            Guid userId,
            OrderStage orderStage,
            float totalPrice
            )
        {
            var existingBookInOrder = await _orderRepository.FindByIdAsync(bookId, userId);
            if (existingBookInOrder != null)
            {
                throw new BookAlreadyExistsInOrderException("test");
            }

            return new Order 
            { 
                BookId = bookId,
                UserId = userId,
                Stage = OrderStage.Created,
                TotalPrice = totalPrice
            };
                
                
        }
    }
}
