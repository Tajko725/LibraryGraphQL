namespace LibraryGraphQL.Api.Models
{
    /// <summary>
    /// Reprezentuje autora książek w systemie bibliotecznym.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Unikalny identyfikator autora.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imię i nazwisko autora.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Lista książek napisanych przez tego autora.
        /// </summary>
        public List<Book> Books { get; set; } = new();
    }
}