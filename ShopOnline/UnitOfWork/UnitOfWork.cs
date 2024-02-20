using ShopOnline.Database;
using ShopOnline.Models;
using ShopOnline.Repository;
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

        /*
         * As we can see when we implement Unit of Work patter then we have to change Repository to not abstract class
         * we need to have sometimes object Repository (when TEntity is not defined before type)
         * To think is good idea to implement that or not (or implement that pattern better)
         */
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if(_reposiories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_reposiories[typeof(TEntity)];
            }

            if (typeof(TEntity) == typeof(Bike))
            {
                var bikeRepository = new BikeRepository(_context);
                 _reposiories.Add(typeof(Bike), bikeRepository);
                return (IRepository<TEntity>)bikeRepository;
            }

            if (typeof(TEntity) == typeof(Customer))
            {
                var customerRepository = new CustomerRepository(_context);
                _reposiories.Add(typeof(Customer), customerRepository);
                return (IRepository<TEntity>)customerRepository;
            }

            var repository = new Repository<TEntity>(_context);
            _reposiories.Add(typeof(TEntity), repository);
            return  repository;
        }

    }
}
