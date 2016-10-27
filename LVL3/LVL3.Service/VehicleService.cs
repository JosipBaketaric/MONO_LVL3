using AutoMapper;
using LVL3.Common;
using LVL3.Common.ViewModels;
using LVL3.Model;
using LVL3.Repository;
using LVL3.Repository.Common;
using LVL3.Repository.Repositorys;
using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service
{
    public class VehicleService : IVehicleService
    {
        private MakeRepository MakeService;
        private ModelRepository ModelService;

        private IRepository WorkingRepository;

        public VehicleService(IRepository workingRepository)
        {
            this.WorkingRepository = workingRepository;
        }
        public  VehicleService()
        {
            this.MakeService =(MakeRepository) new RepositoryFactory(RepositoryType.Make).GetRepository();
            this.ModelService = (ModelRepository)new RepositoryFactory(RepositoryType.Model).GetRepository();
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
        public async void Create(VehicleMakeViewModel make)
        {
            MakeService.Add(Mapper.Map<VehicleMake>(make));
            int result = await MakeService.Complete();
        }
        public async void Create(VehicleModelViewModel model)
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
