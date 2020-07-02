using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data
{
    using BooKeeper.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
