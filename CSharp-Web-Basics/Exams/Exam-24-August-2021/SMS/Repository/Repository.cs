using SMS.Data;
using System.Linq;

namespace SMS.Repository
{
    public class Repository : IRepository
    {
        private readonly SMSDbContext db;

        public Repository(SMSDbContext db)
        {
            this.db = db;
        }

        public void Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            this.db.Add(entity);
        }

        public IQueryable<TEntity> All<TEntity>()
            where TEntity : class
        {
            return this.db.Set<TEntity>();
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}
