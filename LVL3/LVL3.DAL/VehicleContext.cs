using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LVL3.Model.DatabaseModels;
using LVL3.DAL.Common;
using System;

namespace LVL3.DAL
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext() : base("VehicleDB")
        {
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public string ConnectionString
        {
            get
            {
                return this.Database.Connection.ConnectionString;
            }
            set
            {
                this.Database.Connection.ConnectionString = value;
            }
        }

        bool AutoDetachChangedEnabled
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void ExecuteSqlCommand(string p, params object[] os)
        {
            this.Database.ExecuteSqlCommand(p, os);
        }

        public void ExecuteSqlCommand(string p)
        {
            this.Database.ExecuteSqlCommand(p);
        }

        bool IVehicleContext.AutoDetectChangedEnabled
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                this.Configuration.AutoDetectChangesEnabled = value;
            }
        }

    }
}
