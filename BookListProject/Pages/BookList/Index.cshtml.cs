using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListProject.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();  //gets the list of all the records in the db        

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book == null) //if the book does not exist in the db
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync(); //save the changes
            return RedirectToPage("Index");
        }
    }
}