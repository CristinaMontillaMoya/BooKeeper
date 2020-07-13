namespace BooKeeper.Web.Data
{
	using Entities;

	public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
	{
		public SaleDetailRepository(DataContext context) : base(context)
		{
		}
	}
}
