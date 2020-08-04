namespace BooKeeper.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using BooKeeper.Web.Data;
    using BooKeeper.Web.Data.Entities;
    using BooKeeper.Web.Models;
    using System.IO;

    //[Authorize]
    public class BooksController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly DataContext dataContext;

        public BooksController(IBookRepository bookRepository, DataContext dataContext)
        {
            this.bookRepository = bookRepository;
            this.dataContext = dataContext;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(bookRepository.GetAll().OrderBy(b =>b.Title));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            List<Category> categories = dataContext.Categories.ToList();
            ViewBag.CategoriesList = categories;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.png";

                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Books", file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Books/{file}";
                }

                var book = view.Book;
                book.Category = dataContext.Categories.Where(c => c.Id == view.CatId).FirstOrDefault();
                book.Image = path;
                await bookRepository.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Book ToBook(BookViewModel view, string path)
        {
            return new Book
            {
                Id = view.Book.Id,
                Isbn = view.Book.Isbn,
                Category = view.Book.Category,
                Title = view.Book.Title,
                Author = view.Book.Author,
                Date = view.Book.Date,
                Synopsis = view.Book.Synopsis,
                Image = path,
                Price = view.Book.Price,
                Stock = view.Book.Stock
            };
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            var view = ToBookViewModel(book);
            return View(view);
        }

        private BookViewModel ToBookViewModel(Book b)
        {
            return new BookViewModel()
            {
                Book = b
/*
                Id = b.Id,
                Isbn = b.Isbn,
                Category = b.Category,
                Title = b.Title,
                Author = b.Author,
                Date = b.Date,
                Synopsis = b.Synopsis,
                Image = b.Image,
                Price = b.Price,
                Stock = b.Stock*/
            };
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.Book.Image;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.png";

                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Books", file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Books/{file}";
                    }

                    var book = view.Book;
                    book.Image = path;


                    await bookRepository.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExists(view.Book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            await bookRepository.DeleteAsync(book);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(int id)
        {
            return await bookRepository.ExistAsync(id);
        }
    }
}
