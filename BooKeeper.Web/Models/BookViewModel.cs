using BooKeeper.Web.Data.Entities;
namespace BooKeeper.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class BookViewModel : Book
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
