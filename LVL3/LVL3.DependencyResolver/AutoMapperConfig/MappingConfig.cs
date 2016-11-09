using AutoMapper;
using LVL3.DAL.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.DAL.DatabaseModels;
using LVL3.Model.DomainModels;

namespace LVL3.DependencyResolver.AutoMapperConfig
{
    public class MappingConfig : Profile
    {
        protected override void Configure()
        {     
            //Make to Domain

            CreateMap<VehicleMake, VehicleMakeDomain>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMakeDomain>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            //CreateMap<IVehicleMake, IVehicleMakeDomain>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelDomain>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModelDomain>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            //CreateMap<IVehicleModel, IVehicleModelDomain>().ReverseMap();         

            
        }
    }
}
