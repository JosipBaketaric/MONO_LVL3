using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LVL3.Common.ViewModels;
using LVL3.Model;

namespace LVL3.MVC_test.App_Start
{
    public static class MappingConfig
    {

        public static void RegisterMaps()
        {
            Mapper.Initialize(config => 
            {
                config.CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();

                config.CreateMap<VehicleModel, VehicleModelViewModel>()
                .ForMember(dest => dest.VehicleMakeName, opt => opt.MapFrom(src => src.VehicleMake.Name)).ReverseMap();
            });
        }


    }


}