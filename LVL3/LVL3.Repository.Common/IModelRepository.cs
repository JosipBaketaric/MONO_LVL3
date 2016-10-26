using LVL3.Model;
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
        Task<IEnumerable<VehicleModel>> GetAll();
        IEnumerable<VehicleModel> Find(Expression<Func<VehicleModel, bool>> predicate);
        void Add(VehicleModel entity);
        void Remove(VehicleModel entity);
        Task<VehicleModel> SingleOrDefault(Expression<Func<VehicleModel, bool>> predicate);
        Task<VehicleModel> Get(Guid id);
        void Edit(VehicleModel entity);
    }
}
