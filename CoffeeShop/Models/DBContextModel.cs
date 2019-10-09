using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class DBContextModel : DbContext
    {
        public DBContextModel(DbContextOptions<DBContextModel> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
