namespace BooKeeper.Web.Data
{
	using Entities;

	public class BookRepository : GenericRepository<Book>, IBookRepository
	{
		public BookRepository(DataContext context) : base(context)
		{
		}
	}
}
