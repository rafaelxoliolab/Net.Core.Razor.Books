using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net.Core.Razor.Books.Model;

namespace Net.Core.Razor.Books.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet() 
        {
            Books = await db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id) {

            var book = await db.Book.FindAsync(id);
            
            if (book==null)
            {
                return NotFound();
            }

            db.Book.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}