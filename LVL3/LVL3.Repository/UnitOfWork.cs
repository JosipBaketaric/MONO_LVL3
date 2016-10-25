using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Repository.Common;
using LVL3.DAL;

namespace LVL3.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleContext _context;
        private static UnitOfWork instance = null;

        public IMakeRepository makes { get; private set; }
        public IModelRepository models { get; private set; }

        private UnitOfWork()
        {
            this._context = new VehicleContext();
            
            this.makes = new MakeRepository(this._context);
            this.models = new ModelRepository(this._context);
        }

        public static UnitOfWork getInstance()
        {
            if (instance != null)
                return instance;
            instance = new UnitOfWork();
            return instance;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }


}
