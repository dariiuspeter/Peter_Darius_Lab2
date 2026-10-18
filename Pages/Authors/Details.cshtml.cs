using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context _context;

        public DetailsModel(Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author is not null)
            {
                Author = author;
                return Page();
            }

            return NotFound();
        }
    }
}
