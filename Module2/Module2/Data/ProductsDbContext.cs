using Microsoft.EntityFrameworkCore;
using Module2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module2.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
