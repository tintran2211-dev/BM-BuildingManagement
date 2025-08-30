using BM_Management.Domain.AggregateRoots.BManagementRoot.Enums;
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
    [Table("Apartments")]
    public class Apartment : EntityBase
    {
        [Required]
        public int BuildingId { get; set; }
        [MaxLength(15)]
        public string? ApartmentCode { get; set; }
        public int? Floor { get; set; }
        public decimal? Area { get; set; }
        public ApartmentStatus ApartmentStatus { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
