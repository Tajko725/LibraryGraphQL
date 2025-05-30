using LibraryGraphQL.Api.Data;
using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL.Api.Services
{
    /// <summary>
    /// Implementacja serwisu do operacji na książkach.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        /// <summary>
        /// Konstruktor przyjmujący kontekst bazy danych.
        /// </summary>
        /// <param name="context">Kontekst EF Core.</param>
        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            // Pobiera wszystkie książki wraz z informacją o autorze
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Book?> GetByIdAsync(int id)
        {
            // Pobiera książkę na podstawie identyfikatora wraz z autorem
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <inheritdoc />
        public async Task<Book> AddAsync(Book book)
        {
            // Dodaje nową książkę i zapisuje zmiany
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}