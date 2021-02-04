using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using BookStore.Orders;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace BookStore.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<BookStoreDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Order> FindByIdAsync(Guid bookId, Guid userId)
        {
            return await DbSet.FirstOrDefaultAsync(order => order.BookId == bookId && order.UserId == userId);
        }

        public Task<List<Order>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
