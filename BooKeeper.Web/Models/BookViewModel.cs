namespace BooKeeper.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class BookViewModel
    {
        public Book Book { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        public int CatId { get; set; }
    }
}
