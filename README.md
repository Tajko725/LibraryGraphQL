# 📚 LibraryGraphQL

LibraryGraphQL to nowoczesny projekt webowy oparty na .NET 9, zawierający:

* 🔙 Backend API z GraphQL (HotChocolate)
* 📦 EF Core + SQLite jako baza danych
* 🧠 Architektura warstwowa (serwisy, DI, DTO)
* 🌐 Frontend w Blazor WebAssembly (Client)

---

## 📁 Struktura projektu

```
LibraryGraphQL/
├── LibraryGraphQL.Api      # Backend GraphQL API (.NET 9)
├── LibraryGraphQL.Client   # Frontend Blazor WebAssembly (w przygotowaniu)
```

---

## 🔧 Technologie

* .NET 9
* ASP.NET Core Web API
* GraphQL (HotChocolate)
* Entity Framework Core + SQLite
* AutoMapper
* Blazor WebAssembly (dla frontendu)
* StrawberryShake (GraphQL client)
* MudBlazor (UI)

---

## 🧱 Funkcjonalności backendu

* Pobieranie książek i autorów (GraphQL Query)
* Dodawanie książek i autorów (GraphQL Mutation)
* Relacje między `Book` i `Author`
* Automatyczny seeding danych
* Wzorce: DI, separacja warstw, XML docs, komentarze

---

## 📦 Jak uruchomić backend

```bash
cd LibraryGraphQL.Api
dotnet run
```

➡ Serwer GraphQL dostępny pod: `https://localhost:5001/graphql`

Można testować np. w Banana Cake Pop ([https://chillicream.com/docs/nitro/getting-started](https://chillicream.com/docs/nitro/getting-started))

---

## 🧪 Przykładowe zapytanie GraphQL
Skorzystać można z **https://localhost:7046/graphql/**

```graphql
query {
  books {
    id
    title
    author {
      name
    }
  }
}
```

Z wynikiem:
```json
{
  "data": {
    "books": [
      {
        "title": "C# w praktyce",
        "author": {
          "name": "Jan Kowalski"
        }
      },
      {
        "title": "GraphQL dla zaawansowanych",
        "author": {
          "name": "Anna Nowak"
        }
      }
    ]
  }
}
```

---

## 🛠️ Generowanie klienta GraphQL

Aby poprawnie wygenerować klienta GraphQL dla projektu **LibraryGraphQL.Client**, wykonaj poniższe kroki:

### ✅ Wymagania:
- Projekt API (serwer GraphQL) **musi być uruchomiony** pod adresem `https://localhost:7046/graphql`
- Musisz mieć zainstalowany pakiet StrawberryShake CLI:

```
dotnet tool install StrawberryShake.Tools --global
```

---

### 🔧 Kroki:
Uruchom plik **graphql-generate.ps1** lub postępuj zgodnie z poniższymi krokami.

1. **Zainicjalizuj schemat GraphQL (tylko raz):**
   ```bash
   dotnet graphql init https://localhost:7046/graphql
   ```
   To polecenie wygeneruje pliki:
   - `.graphqlrc.json`
   - `schema.graphql`
   - `schema.extensions.graphql`

2. **Popraw nazwę klienta w `.graphqlrc.json`**

   Otwórz `.graphqlrc.json` i zamień:

   ```json
   "name": "LibraryGraphQL.Client"   ← ❌ niepoprawne
   ```

   na:

   ```json
   "name": "LibraryGraphQL_Client"   ← ✅ poprawne
   ```

   > ⚠️ Kropki (`.`) w nazwie klienta powodują błędne generowanie plików — należy je zastąpić podkreśleniami (`_`).

3. **Wygeneruj klienta:**
   ```bash
   dotnet graphql generate
   ```

   Po wykonaniu komendy pojawi się folder `Generated/` z m.in.:

   ```
   Generated/DependencyInjection/ServiceCollectionExtensions.cs
   ```

---

## 🔌 Rejestracja klienta w Blazor WASM (`Program.cs`):

```csharp
builder.Services
    .AddLibraryGraphQL_Client()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7046/graphql"));
```

## ✨ Status

✅ Backend: 80%
🔜 Frontend: w przygotowaniu (Blazor WebAssembly)

---

## 🧑‍💻 Autor

Projekt stworzony przez **Tajko725**
GitHub: [Tajko725](https://github.com/Tajko725)
