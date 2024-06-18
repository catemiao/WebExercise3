using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExercise3.Models;
using System;
using System.Threading.Tasks;
using WebExercise3.Models;

public class DeleteModel : PageModel
{
    private readonly WebAppDbContext _context;

    public DeleteModel(WebAppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        Member = await _context.Member.FindAsync(id);

        if (Member != null)
        {
            _context.Member.Remove(Member);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
