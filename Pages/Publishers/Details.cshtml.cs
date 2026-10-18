using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context _context;

        public DetailsModel(Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher is not null)
            {
                Publisher = publisher;
                return Page();
            }

            return NotFound();
        }
    }
}
