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

        // autorul ales din dropdownlist (filtru)
        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["AuthorID"] = new SelectList(
                _context.Author.OrderBy(a => a.LastName).ThenBy(a => a.FirstName)
                    .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
                "ID", "FullName", AuthorID);

            var books = _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsQueryable();

            if (AuthorID.HasValue)
            {
                books = books.Where(b => b.AuthorID == AuthorID);
            }

            Book = await books.ToListAsync();
        }
    }
}
