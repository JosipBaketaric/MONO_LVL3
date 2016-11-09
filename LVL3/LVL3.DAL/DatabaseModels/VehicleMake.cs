using LVL3.DAL.Common.IDatabase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVL3.DAL.DatabaseModels
{
    public class VehicleMake : IVehicleMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}
