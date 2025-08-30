using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Buildings")]
    public class Building : EntityBase
    {
        [Required, MaxLength(15)]
        public string BuildingCode { get; set; }
        [MaxLength(100)]
        public string? BuildingName { get; set; }
        public string? Address { get; set; }
        public int NumberOfFloors { get; set; }
        public string? Image_Url { get; set; }
    }
}
