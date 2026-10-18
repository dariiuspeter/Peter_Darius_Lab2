# Peter_Darius_Lab2 – ASP.NET Core Razor Pages + EF Core Code First

Laborator 2, Medii de programare – FSEGA.

## Ce contine
- **Models**: `Book` (Title, Price, PublishingDate, PublisherID/Publisher, AuthorID/Author), `Publisher` (PublisherName, Books), `Author` (FirstName, LastName, FullName, Books)
- **Data**: `Peter_Darius_Lab2Context` cu `DbSet<Book>`, `DbSet<Publisher>`, `DbSet<Author>`
- **Pages**: CRUD complet pentru Books, Publishers, Authors
- Books: autorul si editura se aleg din dropdownlist (Create/Edit); Index are filtru pe autor (dropdownlist); Details/Delete afiseaza numele autorului din entitatea Author
- Bara de navigare: Books, Publishers, Authors

## Rulare
1. Deschide `Peter_Darius_Lab2.csproj` in Visual Studio (NuGet restore se face automat).
2. Tools → NuGet Package Manager → Package Manager Console:
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
3. F5 → adauga minim 3 edituri (Humanitas, Nemira, Arthur), autori si 2 carti.
