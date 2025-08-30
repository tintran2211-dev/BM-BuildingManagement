using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("MeterReadings")]
    public class MeterReading
    {
        public string ApartmentCode { get; set; }
        public DateTime ReadingDate { get; set; }
        public int OldElectricNumber { get; set; }
        public int NewElectricNumber { get; set; }
        public int OldWaterNumber { get; set; }
        public int NewWaterNumber { get; set; }
        public string MeterReader { get; set; }
    }
}
