using AutoMapper;
using LVL3.Model.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.Model.Common.IView;
using LVL3.Model.DatabaseModels;
using LVL3.Model.DomainModels;
using LVL3.Model.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace LVL3.DependencyResolver.AutoMapperConfig
{
    public static class MappingConfig
    {
        private static int MAX_DEPTH = 2;
        public static void RegisterMaps()
        {
            
            Mapper.Initialize(config =>
            {
                //Make to Domain
               
                config.CreateMap<VehicleMake, VehicleMakeDomain>().ReverseMap().MaxDepth(MAX_DEPTH);
                config.CreateMap<VehicleMake, IVehicleMakeDomain>().ReverseMap().MaxDepth(MAX_DEPTH);
                config.CreateMap<VehicleMake, IVehicleMake>().ReverseMap().MaxDepth(MAX_DEPTH);
                //config.CreateMap<IVehicleMake, IVehicleMakeDomain>().ReverseMap();

                config.CreateMap<VehicleModel, VehicleModelDomain>().ReverseMap().MaxDepth(MAX_DEPTH);
                config.CreateMap<VehicleModel, IVehicleModelDomain>().ReverseMap().MaxDepth(MAX_DEPTH);
                config.CreateMap<VehicleModel, IVehicleModel>().ReverseMap().MaxDepth(MAX_DEPTH);
                //config.CreateMap<IVehicleModel, IVehicleModelDomain>().ReverseMap();

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
