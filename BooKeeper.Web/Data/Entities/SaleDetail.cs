using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data.Entities
{
    public class SaleDetail
    {
        [Key]
        public int IdSaleDetail { get; set; }

        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        
        [ForeignKey("IsbnFK")]
        [MaxLength(450)]
        public string Isbn { get; set; }

        public virtual Sale Sale { get; set; }
        
        public virtual Book IsbnFK { get; set; }

    }
}
