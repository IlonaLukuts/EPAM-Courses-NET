namespace DataLayer.GenericRepository
{
    using System;

    using System.Collections.Generic;

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        
        void Update(TEntity item);
        
        void Remove(TEntity item);
        
        IList<TEntity> Get();
        
        IList<TEntity> Get(Func<TEntity, bool> predicate);

        IList<TEntity> GetNoTracking();

        IList<TEntity> GetNoTracking(Func<TEntity, bool> predicate);

        TEntity FirstOrDefault(Func<TEntity, bool> predicate);

        void SaveChanges();
    }
}
