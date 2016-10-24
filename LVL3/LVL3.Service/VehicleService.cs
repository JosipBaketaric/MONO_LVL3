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
        public async Task Create(VehicleMake vehicleMake)
        {
            this.db.VehicleMakes.Add(vehicleMake);
            await db.SaveChangesAsync();           
        }

        public async Task Create(VehicleModel vehicleModel)
        {
            this.db.VehicleModels.Add(vehicleModel);
            await db.SaveChangesAsync();
        }

        public async Task DeleteMake(int? id)
        {
            this.db.VehicleMakes.Remove(await db.VehicleMakes.FindAsync(id) );
        }

        public async Task DeleteModel(int? id)
        {
            this.db.VehicleModels.Remove(await db.VehicleModels.FindAsync(id) );
        }

        public async Task<VehicleMake> FindMakeById(int? id)
        {
            VehicleMake vehicleMake = await this.db.VehicleMakes.FindAsync(id);
            return vehicleMake;
        }

        public async Task<VehicleModel> FindModelById(int? id)
        {
            VehicleModel vehicleModel = await this.db.VehicleModels.FindAsync(id);
            return vehicleModel;
        }

        public async Task<IEnumerable> ReadAllMakes()
        {
            IEnumerable<VehicleMake> makesList = await this.db.VehicleMakes.ToListAsync();
            return makesList;
        }

        public async Task<IEnumerable> ReadAllModels()
        {
            IEnumerable<VehicleModel> modelsList = await this.db.VehicleModels.ToListAsync();
            return modelsList;
        }

        public async Task<VehicleMake> ReadMake(int? id)
        {
            return await this.db.VehicleMakes.FindAsync(id);
        }

        public async Task<VehicleModel> ReadModel(int? id)
        {
            return await this.db.VehicleModels.FindAsync(id);
        }

        public async Task Update(VehicleModel vehicleModel)
        {
            this.db.Entry(vehicleModel).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
        }

        public async Task Update(VehicleMake vehicleMake)
        {
            this.db.Entry(vehicleMake).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
        }

    }
}
