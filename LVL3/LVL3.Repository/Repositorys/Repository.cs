using System.Data.Entity;
using System.Threading.Tasks;
using LVL3.Repository.Common;

namespace LVL3.Repository.Repositorys
{
    public abstract class Repository : IRepository
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
