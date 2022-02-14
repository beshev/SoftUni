namespace SharedTrip.Repository
{
    using System.Linq;
    using System.Threading.Tasks;

    using SharedTrip.Data;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync<TEntity>(TEntity model)
            where TEntity : class
        {
            await this.context.Set<TEntity>().AddAsync(model);
        }

        public IQueryable<TEntity> All<TEntity>()
            where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
