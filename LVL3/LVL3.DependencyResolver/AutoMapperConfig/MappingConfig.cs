using AutoMapper;
using LVL3.Model.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.Model.Common.IView;
using LVL3.Model.DatabaseModels;
using LVL3.Model.DomainModels;
using LVL3.Model.ViewModels;

namespace LVL3.DependencyResolver.AutoMapperConfig
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                //Make to Domain
                config.CreateMap<VehicleMake, VehicleMakeDomain>().ReverseMap();    //Imodel to model
                config.CreateMap<VehicleMake, IVehicleMakeDomain>().ReverseMap();
                config.CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, IVehicleMakeDomain>().ReverseMap();


                config.CreateMap<VehicleModel, VehicleModelDomain>().ReverseMap();
                config.CreateMap<VehicleModel, IVehicleModelDomain>().ReverseMap();
                config.CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
                config.CreateMap<IVehicleModel, IVehicleModelDomain>().ReverseMap();



                //Domain to View
                config.CreateMap<VehicleMakeDomain, VehicleMakeView>().ReverseMap();
                config.CreateMap<VehicleMakeDomain, IVehicleMakeView>().ReverseMap();
                config.CreateMap<VehicleMakeDomain, IVehicleMakeDomain>().ReverseMap();
                config.CreateMap<IVehicleMakeDomain, IVehicleMakeView>().ReverseMap();
                config.CreateMap<IVehicleMakeDomain, VehicleMakeView>().ReverseMap();

                
                config.CreateMap<VehicleModelDomain, VehicleModelView>().ReverseMap();
                config.CreateMap<VehicleModelDomain, IVehicleModelView>().ReverseMap();
                config.CreateMap<VehicleModelDomain, IVehicleModelDomain>().ReverseMap();
                config.CreateMap<IVehicleModelDomain, IVehicleModelView>().ReverseMap();
                config.CreateMap<IVehicleModelDomain, VehicleModelView>().ReverseMap();


            });
        }
    }
}
