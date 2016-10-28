using LVL3.Model;
using LVL3.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LVL3.Repository.Common
{ 
    public interface IModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetAll();
        IEnumerable<IVehicleModel> Find(Expression<Func<VehicleModel, bool>> predicate);
        void Add(VehicleModel entity);
        void Remove(IVehicleModel entity);
        Task<IVehicleModel> SingleOrDefault(Expression<Func<VehicleModel, bool>> predicate);
        Task<IVehicleModel> Get(Guid id);
        void Edit(VehicleModel entity);
    }
}
