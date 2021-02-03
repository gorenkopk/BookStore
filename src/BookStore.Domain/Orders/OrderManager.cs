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
            Book book,
            Guid userId,
            OrderStage orderStage
            )
        {
            var existingBookInOrder = await _orderRepository.FindByIdAsync(book.Id, userId);
            if (existingBookInOrder != null)
            {
                throw new BookAlreadyExistsInOrderException(book.Name);
            }

            return new Order 
            { 
                BookId = book.Id,
                UserId = userId,
                Stage = OrderStage.Created,
                TotalPrice = book.Price
            };
                
                
        }
    }
}
