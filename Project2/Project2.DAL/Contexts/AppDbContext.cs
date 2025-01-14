using Microsoft.EntityFrameworkCore;
using Project2.DAL.Models;

namespace Project2.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Service> Services { get; set; }    
    public DbSet<Technician> Technicians { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Technician>()
            .HasOne(t => t.Service)
            .WithMany(t => t.Technicians)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
