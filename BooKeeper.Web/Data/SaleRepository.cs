namespace BooKeeper.Web.Data
{
	using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
	{
        private readonly DataContext context;

        public SaleRepository(DataContext context) : base(context)
		{
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Sales.Include(u => u.User);
        }
    }
}
