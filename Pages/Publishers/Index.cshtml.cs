using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Data;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context _context;

        public IndexModel(Peter_Darius_Lab2.Data.Peter_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
