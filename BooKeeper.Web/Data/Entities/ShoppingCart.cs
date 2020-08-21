using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data.Entities
{
    public class ShoppingCart :IEntity
    {
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public Book Book { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}")]
		public float Price { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}")]
		public double Quantity { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}")]
		public float Total { get { return this.Price * (float)this.Quantity; } }

	}
}
