using BM_Management.Domain.AggregateRoots.BManagementRoot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Services")]
    public class Service
    {
        public string ServiceName { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
