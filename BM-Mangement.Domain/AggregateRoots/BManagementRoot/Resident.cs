using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Residents")]
    public class Resident : EntityBase
    {
        public int ApartmentId { get; set; }
        public string ResidentName { get; set; }
        public DateTime DOB { get; set; }
        public string? CCCD { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsOwner { get; set; }
        }
}
