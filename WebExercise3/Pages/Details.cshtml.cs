using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExercise3.Models;
using System;
using System.Threading.Tasks;
using WebExercise3.Models;

public class DetailsModel : PageModel
{
    private readonly WebAppDbContext _context;

    public DetailsModel(WebAppDbContext context)
    {
        _context = context;
    }

    public Member Member { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        Member = await _context.Member.FindAsync(id);

        if (Member == null)
        {
            return NotFound();
        }
        return Page();
    }
}
