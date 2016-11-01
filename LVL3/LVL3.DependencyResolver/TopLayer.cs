using Ninject.Modules;
using LVL3.Service.Common;
using LVL3.Service;

namespace LVL3.DependencyResolver
{
    public class TopLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IMakeService>().To<MakeService>();
            Bind<IModelService>().To<ModelService>();
        }
    }
}
