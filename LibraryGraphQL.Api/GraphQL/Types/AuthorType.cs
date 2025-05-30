using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;

namespace LibraryGraphQL.Api.GraphQL.Types
{
    /// <summary>
    /// Typ GraphQL reprezentujący encję autora z jego książkami.
    /// </summary>
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Description("Reprezentuje autora książek.");

            descriptor.Field(a => a.Id).Description("Unikalny identyfikator autora.");
            descriptor.Field(a => a.Name).Description("Imię i nazwisko autora.");

            descriptor.Field(a => a.Books)
                .ResolveWith<AuthorResolvers>(r => r.GetBooks(default!, default!))
                .Description("Lista książek napisanych przez tego autora.");
        }

        private class AuthorResolvers
        {
            public IEnumerable<Book> GetBooks(Author author, [Service] IBookService bookService)
            {
                // Pobranie książek powiązanych z autorem
                return bookService.GetAllAsync().Result.Where(b => b.AuthorId == author.Id);
            }
        }
    }
}