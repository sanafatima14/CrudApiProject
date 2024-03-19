using CrudApiProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Metadata;

namespace CrudApiProject.Data
{
    public class api_demo_db_class : DbContext
    {
        public api_demo_db_class(DbContextOptions<api_demo_db_class> options) : base(options) { }
        public DbSet<users> users { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<order_products> order_products { get; set; }
 
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<order_products>()
                  .HasKey(m => new { m.order_id, m.product_id });
            modelBuilder.Entity<users>().HasIndex(s => s.email).IsUnique();
            modelBuilder.Entity<users>().HasIndex(s => s.username).IsUnique();



      modelBuilder.Entity<users>()
     .HasMany<orders>()
     .WithOne( e => e.user ).OnDelete( DeleteBehavior.Restrict )
     .HasForeignKey( e => e.user_id );
           



      modelBuilder.Entity<products>()
                  .HasMany<order_products>()
                  .WithOne(c => c.product).OnDelete( DeleteBehavior.Restrict )
                  .HasForeignKey(p => p.product_id);
            modelBuilder.Entity<orders>()
                  .HasMany<order_products>()
                  .WithOne(c => c.order).OnDelete( DeleteBehavior.Restrict )
                  .HasForeignKey(p => p.order_id);


        }
    }
}
