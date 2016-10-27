using AutoMapper;
using LVL3.Common.ViewModels;
using LVL3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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