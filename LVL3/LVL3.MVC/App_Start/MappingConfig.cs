using AutoMapper;
using LVL3.Model;
using LVL3.Model.Common;
using LVL3.Model.ViewModels;

namespace LVL3.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleMake, VehicleMakeView>().ReverseMap();
                config.CreateMap<VehicleModel, VehicleModelView>().ReverseMap();

                config.CreateMap<IVehicleMake, IVehicleMakeViewModel>().ReverseMap();
                config.CreateMap<IVehicleModel, IVehicleModelViewModel>().ReverseMap();
            });
        }
    }
}