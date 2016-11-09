using AutoMapper;
using LVL3.Model.Common.IDomain;
using LVL3.Model.DomainModels;
using LVL3.MVCApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVL3.MVCApi.AutoMapperConfig
{
    public class Mapping : Profile
    {
        protected override void Configure()
        {
            //Domain to View
            CreateMap<VehicleMakeDomain, VehicleMakeView>().ReverseMap();
            //CreateMap<VehicleMakeDomain, IVehicleMakeView>().ReverseMap();
            CreateMap<VehicleMakeDomain, IVehicleMakeDomain>().ReverseMap();
            //CreateMap<IVehicleMakeDomain, IVehicleMakeView>().ReverseMap();
            CreateMap<IVehicleMakeDomain, VehicleMakeView>().ReverseMap();


            CreateMap<VehicleModelDomain, VehicleModelView>().ReverseMap();
            //CreateMap<VehicleModelDomain, IVehicleModelView>().ReverseMap();
            CreateMap<VehicleModelDomain, IVehicleModelDomain>().ReverseMap();
            //CreateMap<IVehicleModelDomain, IVehicleModelView>().ReverseMap();
            CreateMap<IVehicleModelDomain, VehicleModelView>().ReverseMap();
        }
    }
}