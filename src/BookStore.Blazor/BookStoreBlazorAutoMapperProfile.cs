using AutoMapper;
using BookStore.Books;

namespace BookStore.Blazor
{
    public class BookStoreBlazorAutoMapperProfile : Profile
    {
        public BookStoreBlazorAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
