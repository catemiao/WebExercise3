using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebExercise3.Models;
using System;
using System.Threading.Tasks;

public class EditModel : PageModel
{
    private readonly WebAppDbContext _context;

    public EditModel(WebAppDbContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Member).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MemberExists(Member.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool MemberExists(Guid id)
    {
        return _context.Member.Any(e => e.Id == id);
    }
}
