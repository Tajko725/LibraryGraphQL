using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;

namespace LibraryGraphQL.Api.GraphQL.Types
{
    /// <summary>
    /// Typ GraphQL reprezentujący encję książki z jej relacją do autora.
    /// </summary>
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Reprezentuje książkę w bibliotece.");

            // Pole: Id
            descriptor.Field(b => b.Id).Description("Unikalny identyfikator książki.");

            // Pole: Title
            descriptor.Field(b => b.Title).Description("Tytuł książki.");

            // Pole: Year
            descriptor.Field(b => b.Year).Description("Rok wydania książki.");

            // Pole: AuthorId (ukryte, jeśli niepotrzebne w API)
            descriptor.Field(b => b.AuthorId).Ignore();

            // Pole: Author – relacja
            descriptor.Field(b => b.Author)
                .ResolveWith<BookResolvers>(r => r.GetAuthor(default!, default!))
                .Description("Autor tej książki.");
        }

        private class BookResolvers
        {
            public Author GetAuthor(Book book, [Service] IAuthorService authorService)
            {
                // Pobranie autora dla danej książki
                return authorService.GetByIdAsync(book.AuthorId).Result;
            }
        }
    }
}