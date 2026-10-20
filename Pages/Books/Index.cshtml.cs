using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context _context;

        public IndexModel(Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; } = default!;
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        // autorul ales din dropdownlist (filtru de la lab 2)
        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ViewData["AuthorID"] = new SelectList(
                _context.Author.OrderBy(a => a.LastName).ThenBy(a => a.FirstName)
                    .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
                "ID", "FullName", AuthorID);

            BookD = new BookData();

            var books = _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking();

            if (AuthorID.HasValue)
            {
                books = books.Where(b => b.AuthorID == AuthorID);
            }

            BookD.Books = await books.OrderBy(b => b.Title).ToListAsync();
            Book = BookD.Books.ToList();

            if (id != null)
            {
                BookID = id.Value;
                Book? book = BookD.Books.Where(i => i.ID == id.Value).SingleOrDefault();
                if (book?.BookCategories != null)
                {
                    BookD.Categories = book.BookCategories.Select(s => s.Category);
                }
            }
        }
    }
}
