namespace BooKeeper.Web.Controllers.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BooKeeper.Web.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(bookRepository.GetAllWithCategories());
        }
    }
}
