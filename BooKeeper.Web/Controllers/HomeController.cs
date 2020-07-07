using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BooKeeper.Web.Models;
using BooKeeper.Web.Data.Entities;
using BooKeeper.Web.Data;

namespace BooKeeper.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataContext cntx;

        public HomeController(ILogger<HomeController> logger, DataContext cntx)
        {
            _logger = logger;
            this.cntx = cntx;
        }

        public IActionResult Index()
        {
            Category test = new Category()
            {
                Name = "Terror"
            };
        Book testBook = new Book()
        {
            Isbn = "123124hb4j3bjh",
            Title = "Prueba",
            Author = "Autor",
            Date = DateTime.Now,
            Synopsis = null,
            Image = null,
            Price = 10,
            IdCategory = 1,
            Stock = 1

        };

            cntx.Categories.Add(test);
            if (cntx.SaveChanges() == 1)
            {
                Console.WriteLine(testBook.Author);
                cntx.Books.Add(testBook);
                cntx.SaveChanges();
            }
            else
            {
                Console.WriteLine(testBook.Category);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
