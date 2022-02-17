namespace CarShop.Data.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
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

        public void Delete<TEntity>(TEntity entity) 
            where TEntity : class
        {
            this.db.Remove(entity);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}
