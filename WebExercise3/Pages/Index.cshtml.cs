using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebExercise3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExercise3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebAppDbContext _context;
        public IndexModel(WebAppDbContext context)
        {
            _context = context;
        }
        public IList<Member> Member { get; set; }
        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
