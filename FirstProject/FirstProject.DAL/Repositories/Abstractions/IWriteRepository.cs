using FirstProject.DAL.Models.Base;

namespace FirstProject.DAL.Repositories.Abstractions;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
   Task<T> CreateAsync(T entity);   
   void Update(T entity);
   void SoftDelete(T entity); 
   Task<int> SaveChangeAsync ();
}
