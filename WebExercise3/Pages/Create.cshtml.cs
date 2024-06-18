using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebExercise3.Models;
using System.Threading.Tasks;
using WebExercise3.Models;

public class CreateModel : PageModel
{
    private readonly WebAppDbContext _context;

    public CreateModel(WebAppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Member Member { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Member.Id = Guid.NewGuid();
        _context.Member.Add(Member);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
