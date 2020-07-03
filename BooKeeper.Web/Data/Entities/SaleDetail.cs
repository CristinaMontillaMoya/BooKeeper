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
        public int Id { get; set; }
        public Sale SaleId { get; set; }
        public Book Book { get; set; }

    }
}
