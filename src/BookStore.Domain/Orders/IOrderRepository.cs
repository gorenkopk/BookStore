using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<Order> FindByIdAsync(Guid bookId, Guid userId);
    }
}
