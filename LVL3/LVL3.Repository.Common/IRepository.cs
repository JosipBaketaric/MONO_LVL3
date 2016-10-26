using LVL3.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LVL3.Repository.Common
{
    public interface IRepository
    {
        Task<int> Complete();
        void Dispose();
    }
}
