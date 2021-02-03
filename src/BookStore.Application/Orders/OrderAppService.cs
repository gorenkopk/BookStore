using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.Orders
{
    public class OrderAppService : IOrderAppService
    {
        public Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input)
        {
            throw new NotImplementedException();
        }
    }
}
