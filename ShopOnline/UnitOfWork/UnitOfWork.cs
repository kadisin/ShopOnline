using ShopOnline.Database;
using ShopOnline.Models;
using ShopOnline.Repository.Generics;

namespace ShopOnline.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopOnlineDbContext _context;
        private Dictionary<Type, object> _reposiories;

        public UnitOfWork(ShopOnlineDbContext context )
        {
            _context = context;
            _reposiories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if(_reposiories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_reposiories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            _reposiories.Add(typeof(TEntity), repository);
            return  repository;
        }

    }
}
