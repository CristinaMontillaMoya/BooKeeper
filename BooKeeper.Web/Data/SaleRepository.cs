namespace BooKeeper.Web.Data
{
    using BooKeeper.Web.Helpers;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
	{
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public SaleRepository(DataContext context, IUserHelper userHelper) : base(context)
		{
            this.context = context;
            this.userHelper = userHelper;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Sales.Include(u => u.User);
        }

        public async Task<IQueryable<Sale>> GetSalesAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Sales
                    .Include(o => o.saleDetails)
                    .ThenInclude(i => i.Isbn)
                    .OrderByDescending(o => o.Date);
            }

            return this.context.Sales
                .Include(o => o.saleDetails)
                .ThenInclude(i => i.Isbn)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Date);
        }
    }

}

