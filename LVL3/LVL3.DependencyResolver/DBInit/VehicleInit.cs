using LVL3.DAL;
using LVL3.DAL.DatabaseModels;
using System.Collections.Generic;
using System.Data.Entity;

namespace LVL3.DependencyResolver.DBInit
{
    public class VehicleInit : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicleMakeList = new List<VehicleMake>
            {
                new VehicleMake {Name = "Audi", Abrv = "-" },
                new VehicleMake {Name = "Ferrari", Abrv = "-" },
                new VehicleMake {Name = "Test", Abrv = "-" }
            };

            foreach (var make in vehicleMakeList)
            {
                context.VehicleMakes.Add(make);
            }

            //var VehicleModelList = new List<VehicleModel>
            //{
            //    new VehicleModel {Name = "A4", VehicleMakeId = 1, Abrv = "-" }
            //};          
            //foreach(var model in VehicleModelList)
            //{
            //    context.VehicleModels.Add(model);
            //}

            context.SaveChanges();
            base.Seed(context);
        }
    }

}
