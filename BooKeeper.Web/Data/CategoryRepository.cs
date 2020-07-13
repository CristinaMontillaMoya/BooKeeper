namespace BooKeeper.Web.Data
{
	using Entities;

	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(DataContext context) : base(context)
		{
		}
	}
}
