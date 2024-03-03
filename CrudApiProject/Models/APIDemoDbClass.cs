using Microsoft.EntityFrameworkCore;
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



      //modelBuilder.Entity<Orders>()
      // .HasOne( e => e.user )
      // .WithOne();

      //modelBuilder.Entity<Orders>()
      // .HasOne( e => e.user )
      // .WithOne()
      // .HasForeignKey<Orders>( e => e.user_id)
      // .IsRequired();

      //modelBuilder.Entity<Users>()
      //  .HasOne<Orders>()
      //  .WithOne( e => e.user )
      //  .HasForeignKey<Orders>( e => e.user_id )
      //  .IsRequired();

      modelBuilder.Entity<Users>()
        .HasOne<Orders>()
        .WithOne( e => e.user ).OnDelete( DeleteBehavior.ClientCascade )
    .HasForeignKey<Orders>( e => e.user_id )
        .IsRequired( false );
    }
  }
}
