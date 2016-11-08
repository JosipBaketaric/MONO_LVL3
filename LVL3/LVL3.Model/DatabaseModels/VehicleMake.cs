using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LVL3.Model.Common.IDatabase;

namespace LVL3.Model.DatabaseModels
{
    public class VehicleMake : IVehicleMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}
