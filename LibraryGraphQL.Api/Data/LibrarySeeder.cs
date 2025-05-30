using LibraryGraphQL.Api.Models;

namespace LibraryGraphQL.Api.Data
{
    /// <summary>
    /// Klasa odpowiedzialna za inicjalizację przykładowych danych w bazie.
    /// </summary>
    public static class LibrarySeeder
    {
        /// <summary>
        /// Inicjalizuje przykładowe dane, jeśli baza jest pusta.
        /// </summary>
        /// <param name="context">Kontekst bazy danych.</param>
        public static void Seed(LibraryDbContext context)
        {
            // Sprawdź, czy istnieją dane w tabeli Books
            if (context.Books.Any()) return;

            // Dodaj przykładowych autorów
            var author1 = new Author { Name = "Jan Kowalski" };
            var author2 = new Author { Name = "Anna Nowak" };

            // Dodaj przykładowe książki
            var books = new List<Book>
            {
                new() { Title = "C# w praktyce", Year = 2022, Author = author1 },
                new() { Title = "GraphQL dla zaawansowanych", Year = 2023, Author = author2 }
            };

            context.AddRange(author1, author2);
            context.AddRange(books);
            context.SaveChanges();
        }
    }
}