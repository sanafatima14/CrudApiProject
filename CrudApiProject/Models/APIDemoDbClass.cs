using Microsoft.EntityFrameworkCore;

namespace CrudApiProject.Models
{
  public class APIDemoDbClass:DbContext
  {
    public APIDemoDbClass(DbContextOptions<APIDemoDbClass> options) : base(options) { }
    public DbSet<Users> Users { get; set; }
    public DbSet<Products> products{ get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<orderProducts> orderProducts { get; set; }
    public DbSet<Report> report { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; } 
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      modelBuilder.Entity<orderProducts>()
            .HasKey( m => new { m.Order_id, m.Product_id } );
    }
  }
}
