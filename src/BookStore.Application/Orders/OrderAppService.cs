using BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Orders
{
    [Authorize(BookStorePermissions.Orders.Default)]
    public class OrderAppService : BookStoreAppService, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderManager _orderManager;

        public OrderAppService(
            IOrderRepository orderRepository,
            OrderManager orderManager
            )
        {
            _orderRepository = orderRepository;
            _orderManager = orderManager;
        }

        [Authorize(BookStorePermissions.Orders.Create)]
        public async Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            var order = await _orderManager.CreateAsync(
                input.BookId,
                input.UserId,
                input.Stage,
                input.TotalPrice
                );
            await _orderRepository.InsertAsync(order);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }

        [Authorize(BookStorePermissions.Orders.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await _orderRepository.GetAsync(id);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }

        public Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input)
        {
            throw new NotImplementedException();
        }
    }
}
