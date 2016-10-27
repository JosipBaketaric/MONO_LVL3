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
        Task<IEnumerable<VehicleMake>> GetAll();
        IEnumerable<VehicleMake> Find(Expression<Func<VehicleMake, bool>> predicate);
        void Add(VehicleMake entity);
        void Remove(VehicleMake entity);
        Task<VehicleMake> SingleOrDefault(Expression<Func<VehicleMake, bool>> predicate);
        Task<VehicleMake> Get(Guid id);
        void Edit(VehicleMake entity);
    }
}
