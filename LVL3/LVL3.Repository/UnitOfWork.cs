using LVL3.DAL;
using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVL3.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleContext Context;

        public UnitOfWork(VehicleContext context)
        {
            Context = context;
        }

        //add save and use it in repositorys

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
