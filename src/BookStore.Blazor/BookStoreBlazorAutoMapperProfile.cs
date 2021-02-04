using AutoMapper;
using BookStore.Authors;
using BookStore.Books;
using BookStore.Orders;

namespace BookStore.Blazor
{
    public class BookStoreBlazorAutoMapperProfile : Profile
    {
        public BookStoreBlazorAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();
            CreateMap<AuthorDto, UpdateAuthorDto>();
            CreateMap<OrderDto, CreateOrderDto>();
        }
    }
}
