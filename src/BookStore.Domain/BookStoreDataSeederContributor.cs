using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BookStore.Authors;
using BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IIdentityRoleRepository _identityRoleRepository;
        private readonly IdentityUserManager _identityUserManager;
        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository,
                                                IAuthorRepository authorRepository,
                                                AuthorManager authorManager,
                                                IIdentityUserRepository identityUserRepository,
                                                IdentityUserManager identityUserManager,
                                                IIdentityRoleRepository identityRoleRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;
            _identityRoleRepository = identityRoleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );
            }

            // ADDED SEED DATA FOR AUTHORS

            if (await _authorRepository.GetCountAsync() <= 0)
            {
                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "George Orwell",
                        new DateTime(1903, 06, 25),
                        "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                    )
                );

                await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "Douglas Adams",
                        new DateTime(1952, 03, 11),
                        "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                    )
                );
            }

            // ADD NEW ROLE - CLIENT
            if (await _identityRoleRepository.GetCountAsync() <= 1)
            {
                var userRole = new IdentityRole(new Guid(), "Client");
                userRole.IsPublic = true;
                userRole.IsDefault = true;

                await _identityRoleRepository.InsertAsync(userRole, true);
            }


            // ADD NEW USER - CLIENT

            if (await _identityUserRepository.GetCountAsync() <= 1)
            {
                   await _identityUserRepository.InsertAsync
                    (
                           new IdentityUser(
                               new Guid(),"Client", "client@abp.io"
                               ), 
                           true
                   );
            }

            // ADD CLIENTS ROLE AND PASSWORD

            var client = await _identityUserManager.FindByNameAsync("Client");
            if (client.Roles == null)
            {
                var roles = new List<string> { "Client" };
                await _identityUserManager.SetRolesAsync(client, roles);
            }

            if (client.PasswordHash.IsNullOrEmpty())
            {
                await _identityUserManager.AddPasswordAsync(client, "1q2w3E*");
            }
            
        }
    }
}