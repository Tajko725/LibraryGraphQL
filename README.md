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

---

## ✨ Status

✅ Backend: 80%
🔜 Frontend: w przygotowaniu (Blazor WebAssembly)

---

## 🧑‍💻 Autor

Projekt stworzony przez **Tajko725**
GitHub: [Tajko725](https://github.com/Tajko725)
