using Volo.Abp.Application.Dtos;

namespace BookStore.Orders
{
    public class GetOrderListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
