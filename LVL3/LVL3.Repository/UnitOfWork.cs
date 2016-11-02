using LVL3.DAL;
using LVL3.DAL.Common;
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
        protected IVehicleContext Context;

        public UnitOfWork(IVehicleContext context)
        {
            Context = context;
        }

        public async Task<int> Commit()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

}
