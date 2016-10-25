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
        
        public void Create(VehicleModel vehicleModel)
        {
            this.unitOfWork.models.Add(vehicleModel);
        }

        public void Create(VehicleMake vehicleMake)
        {
            this.unitOfWork.makes.Add(vehicleMake);
        }

        public async void DeleteMake(int id)
        {
            this.unitOfWork.makes.Remove( await this.unitOfWork.makes.Get(id) );
        }

        public async void DeleteModel(int id)
        {
            this.unitOfWork.models.Remove( await this.unitOfWork.models.Get(id) );
        }

        public async Task<IEnumerable<VehicleMake>> ReadAllMakes()
        {
            return await this.unitOfWork.makes.GetAll();
        }

        public async Task <IEnumerable<VehicleModel> > ReadAllModels()
        {
            return await this.unitOfWork.models.GetAll();
        }

        public async Task< VehicleMake > ReadMake(int id)
        {
            return await this.unitOfWork.makes.Get(id);
        }

        public async Task< VehicleModel > ReadModel(int id)
        {
            return await this.unitOfWork.models.Get(id);
        }

        public void Update(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
