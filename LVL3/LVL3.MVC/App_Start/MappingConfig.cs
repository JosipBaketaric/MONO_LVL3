using AutoMapper;
using LVL3.Model;
using LVL3.Model.ViewModels;

namespace LVL3.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
                config.CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
            });
        }
    }
}