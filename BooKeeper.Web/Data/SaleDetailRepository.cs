namespace BooKeeper.Web.Data
{
	using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
	{
        private readonly DataContext context;

        public SaleDetailRepository(DataContext context) : base(context)
		{
            this.context = context;
        }

        public IQueryable GetAllWithBooks()
        {
            return this.context.SaleDetails.Include(b =>b.Isbn.Category);
        }
    }
}
