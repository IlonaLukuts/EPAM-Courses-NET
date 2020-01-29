namespace DataLayer.GenericRepository
{
    using System;
    
    using System.Collections.Generic;

    using System.Linq;
    
    using System.Data.Entity;

    using System.Windows;


    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext dbContext;

        public DbSet<TEntity> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public IList<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public IList<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IList<TEntity> GetNoTracking()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IList<TEntity> GetNoTracking(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
