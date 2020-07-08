using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace BooKeeper.Web.Data.Entities
{
    public class User : IdentityUser
    {

        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters")]
        [Required]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters")]
        [Required]
        public string Surname { get; set; }
    }
}
