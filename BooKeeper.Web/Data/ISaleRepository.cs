namespace BooKeeper.Web.Data
{
    using Entities;
    using System.Linq;

    public interface ISaleRepository : IGenericRepository<Sale>
    {
        IQueryable GetAllWithUsers();
    }
}
