using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BooKeeper.Web.Data.Entities
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public int IdCategory { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Synopsis { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode =false)]
        public float Price { get; set; }

        public int Stock { get; set; }
    }
}
