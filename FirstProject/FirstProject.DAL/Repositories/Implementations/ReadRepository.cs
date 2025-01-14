using FirstProject.DAL.Contexts;
using FirstProject.DAL.Models.Base;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FirstProject.DAL.Repositories.Implementations
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.Where(x => !x.IsDeleted).ToListAsync();  
        }

        public async Task<T> GetByIdAsync(int id)
        {
           var entity = await Table.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
           _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> IsExistsAsync(int id)
        {
           return await Table.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
