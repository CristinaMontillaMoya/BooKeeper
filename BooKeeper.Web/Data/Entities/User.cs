using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BooKeeper.Web.Data.Entities
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters")]
        [Required]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters")]
        [Required]
        public string Surname { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }
    }
}
