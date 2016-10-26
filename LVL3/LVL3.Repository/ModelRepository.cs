using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.DAL;
using LVL3.Model;
using LVL3.Repository.Common;

namespace LVL3.Repository
{
    public class ModelRepository : Repository<VehicleModel>, IModelRepository
    {

        public ModelRepository(VehicleContext context)
            :base(context)
        { }

        public VehicleContext VehicleContext
        {
            get { return context as VehicleContext; }
        }

        public async Task<VehicleModel> Get(Guid id)
        {
            return await this.context.Set<VehicleModel>().FindAsync(id);
        }

        //FILERING AND SEARCHING HERE

    }


}
