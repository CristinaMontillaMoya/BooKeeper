using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BooKeeper.Web.Data.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [MaxLength (30, ErrorMessage = "The field {0} only can contain {1} characters length")]
        [Required]
        public string Name { get; set; }
        
    }
}
