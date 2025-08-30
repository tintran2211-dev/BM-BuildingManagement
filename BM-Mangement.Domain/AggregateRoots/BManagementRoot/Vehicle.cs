using BM_Management.Domain.AggregateRoots.BManagementRoot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public string VehicleCode { get; set; }
        public int ResidentID { get; set; }
        public VehicleType VehicleType { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
