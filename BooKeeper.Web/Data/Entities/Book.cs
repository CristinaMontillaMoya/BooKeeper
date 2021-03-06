﻿namespace BooKeeper.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book : IEntity
    {
        public int Id { get; set; }

        [MaxLength(450)]
        public string Isbn { get; set; }

        public Category Category { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Title { get; set; }

        [MaxLength(75, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Author { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(255, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Synopsis { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode =false)]
        public float Price { get; set; }

        public int Stock { get; set; }

        public string ImageFullPath {
            get
            {
                if (string.IsNullOrEmpty(this.Image))
                {
                    return null;
                }

                return $"https://bookeeperweb.azurewebsites.net{this.Image.Substring(1)}";
            }
        }
    }
}
