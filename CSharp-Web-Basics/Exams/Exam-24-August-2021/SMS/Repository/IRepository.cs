using System.Linq;

namespace SMS.Repository
{
    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>() where TEntity : class;

        public void Add<TEntity>(TEntity entity) where TEntity : class;

        public void SaveChanges();
    }
}
