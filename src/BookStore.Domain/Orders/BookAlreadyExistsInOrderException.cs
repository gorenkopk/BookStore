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
