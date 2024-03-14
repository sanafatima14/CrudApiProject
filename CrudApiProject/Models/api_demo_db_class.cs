using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Metadata;

namespace CrudApiProject.Models
{
  public class api_demo_db_class : DbContext
  {
    public api_demo_db_class( DbContextOptions<api_demo_db_class> options ) : base( options ) { }
    public DbSet<users> users { get; set; }
    public DbSet<products> products { get; set; }
    public DbSet<orders> orders { get; set; }
    public DbSet<order_products> order_products { get; set; }
    //public DbSet<Report> report { get; set; }
    public DbSet<statuses> status { get; set; }
    public DbSet<role> roles { get; set; }
    public DbSet<user_role> user_roles { get; set; }
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      modelBuilder.Entity<users>()
                .Property( ts => ts.email )
                .HasMaxLength( 100 );
      modelBuilder.Entity<users>()
          .Property( ts => ts.password )
          .HasMaxLength( 50 );
      modelBuilder.Entity<users>()
         .Property( ts => ts.username )
         .HasMaxLength( 50 );

      modelBuilder.Entity<role>()
               .Property( ts => ts.name )
               .HasMaxLength( 10 );
      modelBuilder.Entity<role>()
           .Property( ts => ts.description )
           .HasMaxLength( 300 );

      modelBuilder.Entity<order_products>()
            .HasKey( m => new { m.order_id, m.product_id } );
      modelBuilder.Entity<users>().HasIndex( s => s.email ).IsUnique();
      modelBuilder.Entity<users>().HasIndex( s => s.username ).IsUnique();


      modelBuilder.Entity<statuses>()
         .HasMany<orders>()
         .WithOne( e => e.status ).OnDelete( DeleteBehavior.ClientCascade )
     .HasForeignKey( e => e.status_id )
         .IsRequired( false );

      

      modelBuilder.Entity<users>()
         .HasMany<orders>()
         .WithOne( e => e.user ).OnDelete( DeleteBehavior.ClientCascade )
     .HasForeignKey( e => e.user_id )
         .IsRequired( false );

      modelBuilder.Entity<products>()
            .HasMany<order_products>()
            .WithOne( c => c.product ).OnDelete( DeleteBehavior.ClientCascade )
            .HasForeignKey( p => p.product_id );
      modelBuilder.Entity<orders>()
            .HasMany<order_products>()
            .WithOne( c => c.order ).OnDelete( DeleteBehavior.ClientCascade )
            .HasForeignKey( p => p.order_id );






      modelBuilder.Entity<role>()
       .HasOne<user_role>()
       .WithOne( e => e.role ).OnDelete( DeleteBehavior.ClientCascade )
   .HasForeignKey<user_role>( e => e.role_id )
       .IsRequired( false );


      modelBuilder.Entity<users>()
 .HasOne<user_role>()
 .WithOne( e => e.user ).OnDelete( DeleteBehavior.ClientCascade )
.HasForeignKey<user_role>( e => e.user_id )
 .IsRequired( false );

    }
  }
}
