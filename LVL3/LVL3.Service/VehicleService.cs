using AutoMapper;
using LVL3.Common;
using LVL3.Common.ViewModels;
using LVL3.Model;
using LVL3.Repository;
using LVL3.Repository.Repositorys;
using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service
{
    public class VehicleService : IVehicleService
    {
        private static VehicleService instance = null;
        private MakeRepository MakeService;
        private ModelRepository ModelService;
        private VehicleService()
        {
            this.MakeService = (MakeRepository)RepositoryFactory.CreateRepository(RepositoryType.Make);
            this.ModelService = (ModelRepository)RepositoryFactory.CreateRepository(RepositoryType.Model);
        }
        public static VehicleService GetService()
        {
            if (instance != null)
                return instance;
            instance = new VehicleService();
            return instance;
        }
        //Get All
        public async Task<IEnumerable<VehicleMakeViewModel>> ReadAllMakes()
        {
            var MakeList = await MakeService.GetAll();
            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(MakeList);
        }
        public async Task<IEnumerable<VehicleModelViewModel>> ReadAllModels()
        {
            var ModelList = await ModelService.GetAll();
            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(ModelList);
        }
        //Create New
        public void Create(VehicleMakeViewModel make)
        {            
            MakeService.Add(Mapper.Map<VehicleMake>(make));
        }
        public void Create(VehicleModelViewModel model)
        {           
            ModelService.Add(Mapper.Map<VehicleModel>(model));
        }
        //Delete
        public async void DeleteMake(Guid id)
        {
            MakeService.Remove( await MakeService.Get(id) );           
        }
        public async void DeleteModel(Guid id)
        {
            ModelService.Remove( await ModelService.Get(id) );
        }
        //Get One
        public async Task<VehicleMakeViewModel> ReadMake(Guid id)
        {
            return Mapper.Map<VehicleMakeViewModel>(await MakeService.Get(id));
        }
        public async Task<VehicleModelViewModel> ReadModel(Guid id)
        {
            return Mapper.Map<VehicleModelViewModel>(await ModelService.Get(id));
        }
        //Update
        public void Update(VehicleMakeViewModel make)
        {
            MakeService.Edit( Mapper.Map<VehicleMake>(make) );
        }
        public void Update(VehicleModelViewModel model)
        {
            ModelService.Edit( Mapper.Map<VehicleModel>(model) );
        }

    }

}
