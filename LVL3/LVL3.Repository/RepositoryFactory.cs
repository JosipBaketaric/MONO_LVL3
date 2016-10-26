using LVL3.Common;
using LVL3.DAL;
using LVL3.Repository.Repositorys;
using LVL3.Repository.Common;


namespace LVL3.Repository
{
    public static class RepositoryFactory
    {
        public static IRepository CreateRepository(RepositoryType type)
        {
            IRepository resource = null;
            switch (type)
            {
                case RepositoryType.Make:
                    resource = new MakeRepository(new VehicleContext());
                    return resource;

                case RepositoryType.Model:
                    resource = new ModelRepository(new VehicleContext());
                    return resource;

                default:
                    return resource;                
            }
        }

    }

}
