using FirstProject.DAL.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.MVC.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }
    }
}
