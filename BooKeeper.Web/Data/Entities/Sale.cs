using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooKeeper.Web.Data.Entities
{
    [Table("Sale")]
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(25, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Country { get; set; }
        [MaxLength(60, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Province { get; set; }
        public int IdUser { get; set; }
        public string Telephone { get; set; }
        public string DeliveryData { get; set; }

    }
}
