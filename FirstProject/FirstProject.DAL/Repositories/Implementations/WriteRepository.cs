using FirstProject.DAL.Contexts;
using FirstProject.DAL.Models.Base;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.DAL.Repositories.Implementations
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;        
        }
    }
}
