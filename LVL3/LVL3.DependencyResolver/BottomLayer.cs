using Ninject.Modules;
using LVL3.DAL.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.DAL.DatabaseModels;
using LVL3.Model.DomainModels;
using LVL3.DAL;
using LVL3.DAL.Common;

namespace LVL3.DependencyResolver
{
    public class BottomLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();
            
            Bind<IVehicleMakeDomain>().To<VehicleMakeDomain>();
            Bind<IVehicleModelDomain>().To<VehicleModelDomain>();

            Bind<IVehicleContext>().To<VehicleContext>();
        }
    }
}
