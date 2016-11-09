using LVL3.DAL;
using System.Data.Entity;

namespace LVL3.DependencyResolver.DBInit
{
    public static class DBInit
    {
        public static void CallDBInit()
        {
            Database.SetInitializer<VehicleContext>(new VehicleInit());
        }
    }
}
