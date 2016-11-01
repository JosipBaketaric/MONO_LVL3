using Ninject.Modules;
using LVL3.Repository.Common;
using LVL3.Repository.Repositorys;
using LVL3.Repository;

namespace LVL3.DependencyResolver
{
    public class MiddleLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository.Repositorys.Repository>();
            Bind<IMakeRepository>().To<MakeRepository>();
            Bind<IModelRepository>().To<ModelRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
        }
    }
}
