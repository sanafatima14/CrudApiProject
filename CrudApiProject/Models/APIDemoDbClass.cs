using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Metadata;

namespace CrudApiProject.Models
{
  public class APIDemoDbClass : DbContext
  {
    public APIDemoDbClass( DbContextOptions<APIDemoDbClass> options ) : base( options ) { }
    public DbSet<Users> Users { get; set; }
    public DbSet<Products> products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<order_products> orderProducts { get; set; }
    public DbSet<Report> report { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      modelBuilder.Entity<order_products>()
            .HasKey( m => new { m.order_id, m.product_id } );
      modelBuilder.Entity<Users>().HasIndex( s => s.email ).IsUnique();
      modelBuilder.Entity<Users>().HasIndex( s => s.username ).IsUnique();
      modelBuilder.Entity<Report>().HasNoKey();




      modelBuilder.Entity<Users>()
         .HasMany<Orders>()
         .WithOne( e => e.user ).OnDelete( DeleteBehavior.ClientCascade )
     .HasForeignKey( e => e.user_id )
         .IsRequired( false );

      modelBuilder.Entity<Products>()
            .HasMany<order_products>()
            .WithOne( c => c.product ).OnDelete( DeleteBehavior.ClientCascade )
            .HasForeignKey( p => p.product_id );
      modelBuilder.Entity<Orders>()
            .HasMany<order_products>()
            .WithOne( c => c.order ).OnDelete( DeleteBehavior.ClientCascade )
            .HasForeignKey( p => p.order_id );






      modelBuilder.Entity<Role>()
       .HasOne<UserRole>()
       .WithOne( e => e.role ).OnDelete( DeleteBehavior.ClientCascade )
   .HasForeignKey<UserRole>( e => e.role_id )
       .IsRequired( false );


      modelBuilder.Entity<Users>()
 .HasOne<UserRole>()
 .WithOne( e => e.user ).OnDelete( DeleteBehavior.ClientCascade )
.HasForeignKey<UserRole>( e => e.user_id )
 .IsRequired( false );

    }
  }
}
