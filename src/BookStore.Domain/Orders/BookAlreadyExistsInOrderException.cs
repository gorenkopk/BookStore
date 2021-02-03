using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace BookStore.Orders
{
    public class BookAlreadyExistsInOrderException : BusinessException
    {
        public BookAlreadyExistsInOrderException(string name)
            : base(BookStoreDomainErrorCodes.BookAlreadyExistsInOrder)
        {
            WithData("name", name);
        }
    }
}
