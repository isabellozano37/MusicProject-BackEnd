using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Reflection.Emit;
using Data;


namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roll> Roll { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<MyLists> MyLists { get; set; }
        public DbSet<DetailList> DetailList { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
            });

            builder.Entity<Roll>(entity =>
            {
                entity.ToTable("Roll");
            });

            builder.Entity<Products>(entity =>
            {
                entity.ToTable("Products");
            });
            builder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories");
            });
            builder.Entity<MyLists>(entity =>
            {
                entity.ToTable("MyLists");
            });
            builder.Entity<DetailList>(entity =>
            {
                entity.ToTable("DetailList");
            });
        }
    }
}
public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
{
    public ServiceContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
        var config = builder.Build();
        var connectionString = config.GetConnectionString("ServiceContext");
        var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));
        return new ServiceContext(optionsBuilder.Options);
    }
}