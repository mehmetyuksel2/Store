
using System.Reflection;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Repositories;


    public class RepositoryContext: IdentityDbContext<IdentityUser>//dbcontexten türetiyoruz
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        :base(options)//options u dbcontexte yani base e gönderiyoruz
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());
            // **config dosyalarını buraya bu şekilde ekleyedebiliriz ^

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // **daha dinamik şekilde ekleyedebiliriz ^
        }
    }