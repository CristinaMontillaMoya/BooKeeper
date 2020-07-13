namespace BooKeeper.Web.Data
{
	using Entities;

	public class SaleRepository : GenericRepository<Sale>, ISaleRepository
	{
		public SaleRepository(DataContext context) : base(context)
		{
		}
	}
}
