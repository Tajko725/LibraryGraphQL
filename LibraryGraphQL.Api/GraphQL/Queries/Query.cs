using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;

namespace LibraryGraphQL.Api.GraphQL.Queries
{
    /// <summary>
    /// Definiuje zapytania GraphQL dostępne dla klienta.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Pobiera wszystkie książki z serwisu książek.
        /// </summary>
        /// <param name="bookService">Serwis do obsługi książek.</param>
        /// <returns>Lista książek z autorami.</returns>
        public async Task<IEnumerable<Book>> GetBooks([Service] IBookService bookService)
        {
            // Pobierz wszystkie książki z serwisu, łącznie z autorami
            return await bookService.GetAllAsync();
        }

        /// <summary>
        /// Pobiera książkę na podstawie ID.
        /// </summary>
        /// <param name="id">Identyfikator książki.</param>
        /// <param name="bookService">Serwis do obsługi książek.</param>
        /// <returns>Obiekt książki lub null.</returns>
        public async Task<Book?> GetBookById(int id, [Service] IBookService bookService)
        {
            // Pobierz książkę po identyfikatorze
            return await bookService.GetByIdAsync(id);
        }

        /// <summary>
        /// Pobiera wszystkich autorów z serwisu autorów.
        /// </summary>
        /// <param name="authorService">Serwis do obsługi autorów.</param>
        /// <returns>Lista autorów z przypisanymi książkami.</returns>
        public async Task<IEnumerable<Author>> GetAuthors([Service] IAuthorService authorService)
        {
            // Pobierz wszystkich autorów
            return await authorService.GetAllAsync();
        }
    }
}