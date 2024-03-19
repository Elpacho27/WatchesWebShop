using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchesWebShop.Models.Models;

namespace WatchesWebShop.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                Name = "SS",
                DisplayOrder = 1
            }
          
            );
        modelBuilder.Entity<Product>().HasData(

            new
            {
                Id = 2,
                Title = "SSS",
                Description = "SS",
                ISBN = "SS",
                Author = "SSSS",
                ListPrice = 20.1,
                Price = 20.1,
                Price50 = 20.1,
                Price100 = 20.1

        }
            );
        

        
    }



}
