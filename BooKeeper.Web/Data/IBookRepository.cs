namespace BooKeeper.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IBookRepository : IGenericRepository<Book>
    {
        IQueryable GetAllWithCategories();
    }
}
