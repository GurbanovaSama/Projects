using Microsoft.EntityFrameworkCore;
using Project2.BL.Exceptions;
using Project2.BL.Services.Abstractions;
using Project2.DAL.Contexts;
using Project2.DAL.Models;

namespace Project2.BL.Services.Concretes;

public class TechnicianService : ITechnicianService
{
    private readonly AppDbContext _context;

    public TechnicianService(AppDbContext context)
    {
        _context = context;
    }
     
    public DbSet<Technician> Table => _context.Set<Technician>();       

    public async Task CreateAsync(Technician technician)
    {
        await Table.AddAsync(technician);
        int rows = await _context.SaveChangesAsync();
        if (rows != 1)
        {
            throw new Exception("Technician cannot be added");
        }
       
    }

    public async Task<List<Technician>> GetAllAsync()
    {
       List<Technician> technicians =  await Table.ToListAsync();  
        return technicians;

    }

    public async Task<Technician> GetByIdAsync(int id)
    {
        Technician? technician = await Table.FindAsync(id);
        if (technician is null)
        {
            throw new Exception($"technician not foun this id({id})");
        }
        return technician;
        
    }

    public async Task HardDeleteAsync(int id)
    {
        Technician? technician = await Table.FindAsync(id);
        if (technician is null)
        {
            throw new Exception();
        }
        Table.Remove(technician);   
       
    }

    public async Task SoftDeleteAsync(int id)
    {
        Technician? technician = await Table.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (technician is null) 
        {
            throw new Exception();
        }
        technician.IsDeleted = true;
        technician.CreatedAt = DateTime.Now;
        technician.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();  
    
    }

    public async Task UpdateAsync(int id, Technician technician)
    {
        if (technician.Id != id)
        {
            throw new Exception();
        }

        Technician? baseTechnician = await Table.AsNoTracking().SingleOrDefaultAsync(x=> x.Id == id && !x.IsDeleted); 
        
        if (baseTechnician is null)
        {
            throw new Exception();
        }

        technician.CreatedAt = baseTechnician.CreatedAt;
        technician.UpdatedAt = DateTime.Now;

        Table.Update(technician);
        await _context.SaveChangesAsync();

    }
}
