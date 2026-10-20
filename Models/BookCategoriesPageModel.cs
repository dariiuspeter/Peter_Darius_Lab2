using Microsoft.AspNetCore.Mvc.RazorPages;
using Peter_Darius_Lab2.Data;

namespace Peter_Darius_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Peter_Darius_Lab2Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                (book.BookCategories ?? new List<BookCategory>()).Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Peter_Darius_Lab2Context context,
            string[] selectedCategories, Book bookToUpdate)
        {
            // daca nu e bifata nicio categorie, le stergem pe toate cele existente
            selectedCategories ??= Array.Empty<string>();
            bookToUpdate.BookCategories ??= new List<BookCategory>();

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(
                bookToUpdate.BookCategories.Select(c => c.CategoryID));

            foreach (var cat in context.Category.ToList())
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory
                            {
                                BookID = bookToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory bookToRemove = bookToUpdate
                            .BookCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(bookToRemove);
                    }
                }
            }
        }
    }
}
