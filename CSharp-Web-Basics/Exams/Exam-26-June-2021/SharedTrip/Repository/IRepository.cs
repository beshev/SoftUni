namespace SharedTrip.Repository
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>()
            where TEntity : class;

        public Task AddAsync<TEntity>(TEntity model)
            where TEntity : class;

        public Task SaveChangesAsync();
    }
}
