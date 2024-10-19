using LIBRARYMVC_TEST.Models;
using LIBRARYMVC_TEST.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LIBRARYMVC_TEST.Controllers
{
    public class BooksController : Controller
    {
        private readonly DbLibraryMvcContext _DBContext;

        public BooksController(DbLibraryMvcContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            var books = _DBContext.Books.Include(a => a.Author).ToList();
            ViewBag.Message = TempData["Message"];

            return View(books);
        }

        public IActionResult Create()
        {
            BookVM bookVM = new()
            {
                Book = new Book(),
                AuthorList = GetAuthorList()
            };

            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                bookVM.AuthorList = GetAuthorList();
                return View(bookVM);
            }

            _DBContext.Books.Add(bookVM.Book);
            _DBContext.SaveChanges();
            TempData["Message"] = "Libro creado con éxito";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _DBContext.Books.Find(id);
            if (book == null) return NotFound();

            BookVM bookVM = new()
            {
                Book = book,
                AuthorList = GetAuthorList(book.AuthorId)
            };

            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Edit(BookVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                bookVM.AuthorList = GetAuthorList(bookVM.Book.AuthorId);
                return View(bookVM);
            }

            _DBContext.Books.Update(bookVM.Book);
            _DBContext.SaveChanges();
            TempData["Message"] = "Libro editado con éxito";

            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetAuthorList(int? AuthorId = null)
        {
            return [.. _DBContext.Authors
                .Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = a.Id == AuthorId
                })];
        }

        public IActionResult Delete(int id)
        {
            var book = _DBContext.Books.Include(a => a.Author).Where(b => b.Id == id).FirstOrDefault();
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _DBContext.Books.Remove(book);
            _DBContext.SaveChanges();
            TempData["Message"] = "Libro eliminado con éxito";

            return RedirectToAction("Index");
        }
    }
}
