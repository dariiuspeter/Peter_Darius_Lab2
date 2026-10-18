using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context _context;

        public DetailsModel(Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book is not null)
            {
                Book = book;
                return Page();
            }

            return NotFound();
        }
    }
}
