using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data.Entities
{
    public class SaleDetail
    {
        [Key]
        public int IdSaleDetail { get; set; }
        public int SaleId { get; set; }
        public string Isbn { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Book IsbnBook { get; set; }

    }
}
