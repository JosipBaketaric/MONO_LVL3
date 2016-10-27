using LVL3.Common;
using LVL3.DAL;
using LVL3.Repository.Repositorys;
using LVL3.Repository.Common;


namespace LVL3.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IRepository resource;
        public RepositoryFactory(RepositoryType type)
        {
            
            switch (type)
            {
                case RepositoryType.Make:
                    resource = new MakeRepository(new VehicleContext());
                    break;
                case RepositoryType.Model:
                    resource = new ModelRepository(new VehicleContext());
                    break;
                default:
                    resource = null;
                    break;               
            }
        }

        public IRepository GetRepository()
        {
            return this.resource;
        }

    }

}
