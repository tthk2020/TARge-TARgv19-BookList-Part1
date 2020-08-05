using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListProject.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //now the Book model will be accessible to the page model
        [BindProperty] //biding a property means that on post request this very object Book is passed to the OnPost() method
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
              //adding the object to the qeue
                await _db.Book.AddAsync(Book);
                //adding the book to the database
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
                
            } else
            {
                return Page();
            }
        }
    }
}