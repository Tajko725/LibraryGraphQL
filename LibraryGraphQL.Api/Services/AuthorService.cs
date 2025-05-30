using LibraryGraphQL.Api.Data;
using LibraryGraphQL.Api.Models;
using LibraryGraphQL.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL.Api.Services
{
    /// <summary>
    /// Implementacja serwisu do operacji na autorach.
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _context;

        /// <summary>
        /// Konstruktor przyjmujący kontekst bazy danych.
        /// </summary>
        /// <param name="context">Kontekst EF Core.</param>
        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            // Pobiera wszystkich autorów wraz z listą ich książek
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Author?> GetByIdAsync(int id)
        {
            // Pobiera autora na podstawie identyfikatora wraz z książkami
            return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <inheritdoc />
        public async Task<Author> AddAsync(Author author)
        {
            // Dodaje nowego autora i zapisuje zmiany
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}