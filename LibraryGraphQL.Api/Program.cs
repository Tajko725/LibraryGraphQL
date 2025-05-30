using LibraryGraphQL.Api.Data;
using LibraryGraphQL.Api.Extensions;
using LibraryGraphQL.Api.GraphQL.Mutations;
using LibraryGraphQL.Api.GraphQL.Queries;
using LibraryGraphQL.Api.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodaj kontekst EF Core i SQLite
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlite("Data Source=LibraryGraphQL.db"));

            // Dodaj AutoMapper i serwisy
            builder.Services.AddApplicationServices();

            // GraphQL konfiguracja
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<BookType>()
                .AddType<AuthorType>();


            var app = builder.Build();

            // Migracja + seeding danych
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                dbContext.Database.Migrate();
                LibrarySeeder.Seed(dbContext);
            }

            app.MapGraphQL();

            app.Run();
        }
    }
}
