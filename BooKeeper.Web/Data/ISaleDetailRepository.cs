namespace BooKeeper.Web.Data
{
    using Entities;
    using System.Linq;

    public interface ISaleDetailRepository : IGenericRepository<SaleDetail>
    {
        IQueryable GetAllWithBooks();
    }
}
