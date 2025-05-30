using LibraryGraphQL.Api.Services;
using LibraryGraphQL.Api.Services.Interfaces;

namespace LibraryGraphQL.Api.Extensions
{
    /// <summary>
    /// Klasa rozszerzająca IServiceCollection o rejestrację serwisów aplikacji.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Rejestruje serwisy aplikacji do kontenera DI.
        /// </summary>
        /// <param name="services">Kolekcja usług do rozbudowy.</param>
        /// <returns>Rozszerzona kolekcja usług.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Rejestracja serwisów jako scoped (na żądanie)
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            // AutoMapper i inne zależności mogą być dodane tutaj w przyszłości
            return services;
        }
    }
}