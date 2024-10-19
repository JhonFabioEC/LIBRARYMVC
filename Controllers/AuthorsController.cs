using LIBRARYMVC_TEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARYMVC_TEST.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DbLibraryMvcContext _DBContext;

        public AuthorsController(DbLibraryMvcContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            var authors = _DBContext.Authors.ToList();
            ViewBag.Message = TempData["Message"];

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid) return View(author);

            _DBContext.Authors.Add(author);
            _DBContext.SaveChanges();
            TempData["Message"] = "Autor creado con éxito";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var author = _DBContext.Authors.Find(id);
            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid) return View(author);

            _DBContext.Authors.Update(author);
            _DBContext.SaveChanges();
            TempData["Message"] = "Autor editado con éxito";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var author = _DBContext.Authors.Where(a => a.Id == id).FirstOrDefault();
            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(Author author)
        {
            _DBContext.Authors.Remove(author);
            _DBContext.SaveChanges();
            TempData["Message"] = "Autor eliminado con éxito";

            return RedirectToAction("Index");
        }
    }
}
