using LibraryGraphQL.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL.Api.Data
{
    /// <summary>
    /// Kontekst bazy danych dla systemu bibliotecznego.
    /// Zarządza encjami książek i autorów.
    /// </summary>
    public class LibraryDbContext : DbContext
    {
        /// <summary>
        /// Konstruktor przyjmujący opcje DbContext.
        /// </summary>
        /// <param name="options">Opcje konfiguracji DbContext.</param>
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        /// <summary>
        /// Kolekcja książek w bazie danych.
        /// </summary>
        public DbSet<Book> Books => Set<Book>();

        /// <summary>
        /// Kolekcja autorów w bazie danych.
        /// </summary>
        public DbSet<Author> Authors => Set<Author>();
    }
}