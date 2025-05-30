using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;

namespace LibraryGraphQL.Api.GraphQL.Mutations
{
    /// <summary>
    /// Definiuje operacje mutacji GraphQL (zmiany danych).
    /// </summary>
    public class Mutation
    {
        /// <summary>
        /// Dodaje nową książkę do bazy danych.
        /// </summary>
        /// <param name="title">Tytuł książki.</param>
        /// <param name="year">Rok wydania książki.</param>
        /// <param name="authorId">Id autora powiązanego z książką.</param>
        /// <param name="bookService">Serwis książek.</param>
        /// <returns>Nowo dodana książka.</returns>
        public async Task<Book> AddBook(
            string title,
            int year,
            int authorId,
            [Service] IBookService bookService)
        {
            // Tworzenie obiektu książki z przekazanymi danymi
            var book = new Book
            {
                Title = title,
                Year = year,
                AuthorId = authorId
            };

            // Dodanie książki do bazy
            return await bookService.AddAsync(book);
        }

        /// <summary>
        /// Dodaje nowego autora do bazy danych.
        /// </summary>
        /// <param name="name">Imię i nazwisko autora.</param>
        /// <param name="authorService">Serwis autorów.</param>
        /// <returns>Nowo dodany autor.</returns>
        public async Task<Author> AddAuthor(
            string name,
            [Service] IAuthorService authorService)
        {
            // Tworzenie obiektu autora
            var author = new Author
            {
                Name = name
            };

            // Dodanie autora do bazy
            return await authorService.AddAsync(author);
        }
    }
}