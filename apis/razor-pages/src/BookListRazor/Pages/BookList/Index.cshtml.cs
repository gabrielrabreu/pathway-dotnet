using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> Books { get; set; }

        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task OnGet()
        {
            Books = await _applicationDbContext.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _applicationDbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _applicationDbContext.Books.Remove(book);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
