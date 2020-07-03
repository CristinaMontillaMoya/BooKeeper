using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooKeeper.Web.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public List<SaleDetail> SaleDetail { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public int IdUser { get; set; }
        public string telephone { get; set; }
        public string DeliveryData { get; set; }

    }
}
