using LibraryGraphQL.Api.Models;

namespace LibraryGraphQL.Api.Services.Interfaces
{
    /// <summary>
    /// Interfejs definiujący operacje na encjach autorów.
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Pobiera wszystkich autorów z bazy.
        /// </summary>
        /// <returns>Lista wszystkich autorów.</returns>
        Task<IEnumerable<Author>> GetAllAsync();

        /// <summary>
        /// Pobiera autora po identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator autora.</param>
        /// <returns>Autor lub null.</returns>
        Task<Author?> GetByIdAsync(int id);

        /// <summary>
        /// Dodaje nowego autora do bazy.
        /// </summary>
        /// <param name="author">Obiekt autora.</param>
        /// <returns>Dodany autor.</returns>
        Task<Author> AddAsync(Author author);
    }
}