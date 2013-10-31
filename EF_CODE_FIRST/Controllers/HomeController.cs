using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_CODE_FIRST.Context;
using EF_CODE_FIRST.Models;

namespace EF_CODE_FIRST.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksContext _booksContext;

        public HomeController()
        {
            _booksContext = new BooksContext();
        }

        public HomeController(BooksContext context)
        {
            _booksContext = context;
        }


        //
        // GET: /Home/

        public ActionResult Index()
        {
            var books = _booksContext.Books.ToList();

            return View(books);
        }

        public ViewResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Books books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _booksContext.Books.Add(books);
                    _booksContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return View(books);

        }

        // GET
        public ViewResult Editar(int id)
        {
            var libro = _booksContext.Books.Find(id);


            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Books book)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    _booksContext.Entry(book).State = System.Data.EntityState.Modified;
                  _booksContext.SaveChanges();

                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {
                
                throw;
            }


            return View(book);
        }


        public ViewResult Eliminar(int id)
        {
            var libro = _booksContext.Books.Find(id);

            return View(libro);
            
        }

        [HttpPost]
        public ActionResult Eliminar(Books books)
        {
            _booksContext.Entry(books).State = System.Data.EntityState.Deleted;

            _booksContext.SaveChanges();

            return RedirectToAction("Index");

        }


        public PartialViewResult Busqueda(string busqueda)
        {
            var libros = _booksContext.Books.Where(b => b.Title.Contains(busqueda) || b.Author.Contains(busqueda)).ToList();

            return PartialView("Index",libros);
                
        }


    }
}
