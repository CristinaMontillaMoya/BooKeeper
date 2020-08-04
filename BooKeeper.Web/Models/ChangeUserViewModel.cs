namespace BooKeeper.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
    }
}
