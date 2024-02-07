using System.Linq.Expressions;

namespace ShopOnline.Repository.Generics
{
    // Abstract repository working on TEntity entity
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Get all elements from database
        /// </summary>
        /// <returns>List of elements</returns>
        public Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Get elements that equals filter function
        /// </summary>
        /// <param name="predicate">Predicate (filter function)</param>
        /// <returns>IQueryable of elements - because we want to filter data on database</returns>
        public Task<IEnumerable<TEntity>> GetWithFilter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get element by key
        /// </summary>
        /// <param name="id">Unique id of entity</param>
        /// <returns>Element T</returns>
        public Task<TEntity> GetById(Guid id);

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity">Entity to add to database</param>
        /// <returns>Entity</returns>
        public Task<TEntity> Add(TEntity entity);

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity">Existing in database entity</param>
        /// <returns>Entity</returns>
        public Task<TEntity> Update(TEntity entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <returns>Entity</returns>
        public Task<TEntity> Delete(TEntity entity);
    }
}
