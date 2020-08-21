namespace BooKeeper.Web.Data
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ISaleRepository : IGenericRepository<Sale>
    {
        IQueryable GetAllWithUsers();

        Task<IQueryable<Sale>> GetSalesAsync(string userName);

    }
}
