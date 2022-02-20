namespace FootballManager.Data.Common
{
    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>() where TEntity : class;

        public void Add<TEntity>(TEntity entity) where TEntity : class;

        public void Remove<TEntity>(TEntity entity) where TEntity : class;

        public void SaveChanges();
    }
}
