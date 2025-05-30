namespace LibraryGraphQL.Api.Models
{
    /// <summary>
    /// Reprezentuje książkę w systemie bibliotecznym.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unikalny identyfikator książki.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tytuł książki.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Rok wydania książki.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Identyfikator autora (klucz obcy).
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Powiązany autor książki.
        /// </summary>
        public Author? Author { get; set; }
    }
}