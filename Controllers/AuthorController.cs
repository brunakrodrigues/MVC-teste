using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_with_EF.Context;
using MVC_with_EF.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_with_EF.Controllers
{
    public class AuthorController : Controller
    {
        public DBBlogContext _context;
        public AuthorController (DBBlogContext context) {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var authors = _context.Author.ToList();
            ViewData["authors"] = authors;

            return View();
        }

        public IActionResult Create(int AuthorID)
        {
            var author = _context.Author.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (author == null)
            {
                return View(new AuthorViewModel { });

            }
            else {
                return View(new AuthorViewModel
                {
                    AuthorID = author.AuthorID,
                    Name = author.Name
                });
            }
           
        }

        public IActionResult Delete(int AuthorID)
        {
            var author = _context.Author.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (author != null)
            {
                _context.Author.Remove(author);
                _context.SaveChanges();

            } 

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Add(AuthorViewModel request)
        {
            if (request.AuthorID > 0)
            {

                var author = _context.Author.SingleOrDefault(x => x.AuthorID == request.AuthorID);
                if (author != null)
                {
                    author.Name = request.Name;
                }
                _context.Author.Update(author);


            }
            else
            {
                _context.Author.Add(new Context.Models.Author
                {
                    Name = request.Name
                });
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
