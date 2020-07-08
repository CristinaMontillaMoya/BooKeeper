using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data
{
    using BooKeeper.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
