using FirstProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }


    public DbSet<CartItem> CartItems { get; set; }      
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
