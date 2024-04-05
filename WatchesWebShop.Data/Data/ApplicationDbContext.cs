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
                Id = 1,
                Brand="Casio",
                Series="144-GT",
                ModelNumber="5566",
                Price=556.99,
                CategoryID=1,
                ImageURL=""
            }) ;
            
            
    }   
 }




