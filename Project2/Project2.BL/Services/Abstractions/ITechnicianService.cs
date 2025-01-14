using Microsoft.EntityFrameworkCore;
using Project2.DAL.Models;

namespace Project2.BL.Services.Abstractions;

public interface ITechnicianService
{
    Task<List<Technician>> GetAllAsync();
    Task<Technician> GetByIdAsync(int id);
    Task CreateAsync (Technician technician);       
    Task UpdateAsync (int id,Technician technician);
    Task SoftDeleteAsync(int id);   
    Task HardDeleteAsync(int id);
    

}
