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
    public interface IMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetAll();
        IEnumerable<IVehicleMake> Find(Expression<Func<VehicleMake, bool>> predicate);
        void Add(VehicleMake entity);
        void Remove(IVehicleMake entity);
        Task<IVehicleMake> SingleOrDefault(Expression<Func<VehicleMake, bool>> predicate);
        Task<IVehicleMake> Get(Guid id);
        void Edit(VehicleMake entity);
    }
}
