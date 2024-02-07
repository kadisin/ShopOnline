using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace ShopOnline.Repository.Generics
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected DbContext _context;


        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(TEntity entity)
        {
            var isElementExis = await _context.Set<TEntity>().FindAsync(entity);
            if (isElementExis != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            else
            {
                throw new ArgumentException(nameof(TEntity));
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var element = await _context.Set<TEntity>().FindAsync(id);
            if (element != null)
            {
                return element;
            }
            else
            {
                throw new ArgumentException(nameof(TEntity));
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsQueryable().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
