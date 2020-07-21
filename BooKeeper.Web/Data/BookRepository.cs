namespace BooKeeper.Web.Data
{
	using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BookRepository : GenericRepository<Book>, IBookRepository
	{
        private readonly DataContext context;

        public BookRepository(DataContext context) : base(context)
		{
            this.context = context;
        }

        public IQueryable GetAllWithCategories()
        {
            return this.context.Books.Include(c => c.Category);
        }
    }
}
