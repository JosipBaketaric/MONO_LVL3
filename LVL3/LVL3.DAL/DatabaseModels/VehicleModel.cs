using LVL3.DAL.Common.IDatabase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVL3.DAL.DatabaseModels
{
    public class VehicleModel : IVehicleModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleModelId { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("VehicleMake")]
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
