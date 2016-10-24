using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Service.Common;
using LVL3.DAL;
using LVL3.Model;


namespace LVL3.Service
{
    public class VehicleService : IVehicleService
    {
        private static VehicleService instance = null;
        private VehicleContext db;
        private VehicleService()
        {
            this.db = new VehicleContext();
        }
        public VehicleService GetInstance()
        {
            if (instance != null)
                return instance;
            instance = new VehicleService();
            return instance;
        }
        public bool Create(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public bool Create(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMake(int? id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModel(int? id)
        {
            throw new NotImplementedException();
        }

        public LVL3.Model.VehicleMake FindMakeById(int? id)
        {
            throw new NotImplementedException();
        }

        public LVL3.Model.VehicleModel FindModelById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable ReadAllMakes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable ReadAllModels()
        {
            throw new NotImplementedException();
        }

        public LVL3.Model.VehicleMake ReadMake(int? id)
        {
            throw new NotImplementedException();
        }

        public LVL3.Model.VehicleModel ReadModel(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Update(LVL3.Model.VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(LVL3.Model.VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
