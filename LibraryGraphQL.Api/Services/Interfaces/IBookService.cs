using LibraryGraphQL.Api.Models;

namespace LibraryGraphQL.Api.Services.Interfaces
{
    /// <summary>
    /// Interfejs definiujący operacje na encjach książek.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Pobiera wszystkie książki z bazy.
        /// </summary>
        /// <returns>Lista wszystkich książek.</returns>
        Task<IEnumerable<Book>> GetAllAsync();

        /// <summary>
        /// Pobiera książkę po identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator książki.</param>
        /// <returns>Książka lub null.</returns>
        Task<Book?> GetByIdAsync(int id);

        /// <summary>
        /// Dodaje nową książkę do bazy.
        /// </summary>
        /// <param name="book">Obiekt książki.</param>
        /// <returns>Dodana książka.</returns>
        Task<Book> AddAsync(Book book);
    }
}