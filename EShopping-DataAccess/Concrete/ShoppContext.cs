using System;
using EShopping_Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace EShopping_DataAccess.Concrete
{
    public class ShoppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Username=postgres;Password=1425369As;Server=localhost;Port=5433;Database=EshopDBB;
                                      Integrated Security=true;Pooling=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(z => new { z.CategoryID, z.ProductID });
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryID);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.Products)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductID);


          /*  modelBuilder.Entity<Products>()
                .HasOne<Bodysize>(s => s.Bodysize)
                .WithMany(d => d.Products)
                .HasForeignKey(c => c.BodyID);*/
        }
        public DbSet<Products> products  { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<basket> baskets { get; set; }



    }
}
