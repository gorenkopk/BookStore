using BookStore.Authors;
using BookStore.Books;
using BookStore.Orders;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

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
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
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
                b.ToTable(BookStoreConsts.DbTablePrefix + "Orders",
                    BookStoreConsts.DbSchema);

                b.ConfigureByConvention();
                b.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId).IsRequired();
                b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId);
            });


        }
    }
}