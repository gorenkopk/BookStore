using BookStore.Authors;
using BookStore.Books;
using BookStore.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));


            builder.Entity<Book>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Books", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); 
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Authors", BookStoreConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });

            builder.Entity<Order>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Orders", BookStoreConsts.DbSchema);
                b.ConfigureByConvention();

                b.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId);
            });

        }
    }
}