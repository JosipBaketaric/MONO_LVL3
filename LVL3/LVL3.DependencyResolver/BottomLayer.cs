using Ninject.Modules;
using LVL3.Model.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.Model.Common.IView;
using LVL3.Model.DatabaseModels;
using LVL3.Model.DomainModels;
using LVL3.Model.ViewModels;

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

            Bind<IVehicleMakeView>().To<VehicleMakeView>();
            Bind<IVehicleModelView>().To<VehicleModelView>();
        }
    }
}
