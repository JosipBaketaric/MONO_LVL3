using AutoMapper;
using LVL3.Common;
using LVL3.Model;
using LVL3.Repository;
using LVL3.Repository.Repositorys;
using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.ViewModels;
using LVL3.Model.Common;
using LVL3.DAL;

namespace LVL3.Service
{
    public class VehicleService : IVehicleService
    {
        private MakeRepository MakeService;
        private ModelRepository ModelService;

        private VehicleContext VehicleContext;

        public  VehicleService(VehicleContext vehicleContext)
        {
            this.VehicleContext = vehicleContext;

            this.MakeService =(MakeRepository) new RepositoryFactory(RepositoryType.Make, VehicleContext).GetRepository();
            this.ModelService = (ModelRepository)new RepositoryFactory(RepositoryType.Model, VehicleContext).GetRepository();
        }

        //Get All
        public async Task<IEnumerable<VehicleMakeView>> ReadAllMakes()
        {
            var makeList = await MakeService.GetAll();
            return Mapper.Map<IEnumerable<VehicleMakeView>>(makeList);
        }
        public async Task<IEnumerable<VehicleModelView>> ReadAllModels()
        {
            var ModelList = await ModelService.GetAll();
            return Mapper.Map<IEnumerable<VehicleModelView>>(ModelList);
        }
        //Create New
        public async void Create(VehicleMakeView make)
        {
            MakeService.Add(Mapper.Map<VehicleMake>(make));
            int result = await MakeService.Complete();
        }
        public async void Create(VehicleModelView model)
        {
            ModelService.Add(Mapper.Map<VehicleModel>(model));
            int result = await ModelService.Complete();
        }
        //Delete
        public async void DeleteMake(Guid id)
        {
            MakeService.Remove( await MakeService.Get(id) );
            int result = await MakeService.Complete();
        }
        public async void DeleteModel(Guid id)
        {
            ModelService.Remove( await ModelService.Get(id) );
            int result = await ModelService.Complete();
        }
        //Get One
        public async Task<VehicleMakeView> ReadMake(Guid id)
        {
            return Mapper.Map<VehicleMakeView>(await MakeService.Get(id));
        }
        public async Task<VehicleModelView> ReadModel(Guid id)
        {
            return Mapper.Map<VehicleModelView>(await ModelService.Get(id));
        }
        //Update
        public async void Update(VehicleMakeView make)
        {
            MakeService.Edit( Mapper.Map<VehicleMake>(make) );
            int result = await MakeService.Complete();
        }
        public async void Update(VehicleModelView model)
        {
            ModelService.Edit( Mapper.Map<VehicleModel>(model) );
            int result = await ModelService.Complete();
        }
    }

}
