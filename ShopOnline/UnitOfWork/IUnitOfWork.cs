using ShopOnline.Models;
using ShopOnline.Repository.Generics;

namespace ShopOnline.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
