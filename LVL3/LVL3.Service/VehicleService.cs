using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Service.Common;
using LVL3.DAL;
using LVL3.Model;
using System.Data.Entity;
using LVL3.Repository;
using LVL3.Common.ViewModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace LVL3.Service
{
    public class VehicleService : IVehicleService
    {
        private UnitOfWork unitOfWork;
        private static VehicleService instance = null;

        private VehicleService()
        {
            this.unitOfWork = UnitOfWork.getInstance();
        }

        public static VehicleService getInstance()
        {
            if (instance != null)
                return instance;
            instance = new VehicleService();
            return instance;
        }
        
        public void Create(VehicleModelViewModel vehicleModelViewModel)
        {
            this.unitOfWork.models.Add( Mapper.Map<VehicleModel>(vehicleModelViewModel) );
        }

        public void Create(VehicleMakeViewModel vehicleMakeViewModel)
        {
            this.unitOfWork.makes.Add( Mapper.Map<VehicleMake>(vehicleMakeViewModel) );
        }

        public async void DeleteMake(int id)
        {
            this.unitOfWork.makes.Remove( await this.unitOfWork.makes.Get(id) );
        }

        public async void DeleteModel(int id)
        {
            this.unitOfWork.models.Remove( await this.unitOfWork.models.Get(id) );
        }

        public async Task<IEnumerable<VehicleMakeViewModel >> ReadAllMakes()
        {
            IEnumerable vehicleMakeList = await this.unitOfWork.makes.GetAll();
            IQueryable vehicleMakelListQueryable = vehicleMakeList.AsQueryable();

            IEnumerable<VehicleMakeViewModel> vehicleMakeViewModelReturnList = await vehicleMakelListQueryable.ProjectTo<VehicleMakeViewModel>().ToListAsync();

            return vehicleMakeViewModelReturnList;
        }

        public async Task <IEnumerable<VehicleModelViewModel> > ReadAllModels()
        {
            IEnumerable vehicleModelList = await this.unitOfWork.models.GetAll();
            IQueryable vehicleModelListQueryable = vehicleModelList.AsQueryable();

            IEnumerable<VehicleModelViewModel> vehicleModelViewModelReturnList = await vehicleModelListQueryable.ProjectTo<VehicleModelViewModel>().ToListAsync();

            return vehicleModelViewModelReturnList;
        }

        public async Task< VehicleMakeViewModel > ReadMake(int id)
        {
            VehicleMake vehicleMake = await this.unitOfWork.makes.Get(id);
            return Mapper.Map<VehicleMakeViewModel>(vehicleMake);
        }

        public async Task< VehicleModelViewModel > ReadModel(int id)
        {
            VehicleModel vehicleModel = await this.unitOfWork.models.Get(id);
            return Mapper.Map<VehicleModelViewModel>(vehicleModel);
        }

        public void Update(VehicleMakeViewModel vehicleMakeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleModelViewModel vehicleModelViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
