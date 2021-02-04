using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<OrderDto> GetAsync(Guid id);

        Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input);

        Task<OrderDto> CreateAsync(CreateOrderDto input);

        Task DeleteAsync(Guid id);
    }
}
