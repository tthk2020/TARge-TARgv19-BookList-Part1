using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookListProject.Controllers
{
    [Route("api/Book")] //the route at which the API is called
    [ApiController] //specifying that the class is the API controller
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        //implementing HTTP GET
        [HttpGet]
        public IActionResult Index()
        {
            //returning data from the db in JSON format
            return Json(new { data = _db.Book.ToList() });
        }
    }
}
