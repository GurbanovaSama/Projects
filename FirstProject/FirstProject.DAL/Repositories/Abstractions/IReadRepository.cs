using FirstProject.DAL.Models.Base;

namespace FirstProject.DAL.Repositories.Abstractions;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task<ICollection<T>> GetAllAsync(); 
    Task<T> GetByIdAsync(int id);
    Task<bool> IsExistsAsync(int id);    
}
