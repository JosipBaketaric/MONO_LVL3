using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Repository.Common;
using LVL3.Model;
using LVL3.DAL;

namespace LVL3.Repository
{
    public class MakeRepository : Repository<VehicleMake>, IMakeRepository
    {
        public MakeRepository(VehicleContext context) : base(context)
        {
        }

        public VehicleContext VehicleContext
        {
            get { return context as VehicleContext; }
        }

        public async Task<VehicleMake> Get(Guid id)
        {
            return await this.context.Set<VehicleMake>().FindAsync(id);
        }

        //FILERING AND SEARCHING HERE

    }
}
