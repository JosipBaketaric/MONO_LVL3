using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVL3.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IMakeRepository makes { get; }
        IModelRepository models { get; }
        Task<int> Complete();
    }
}
