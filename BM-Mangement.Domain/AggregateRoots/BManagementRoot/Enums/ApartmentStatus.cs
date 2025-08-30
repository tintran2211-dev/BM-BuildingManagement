using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot.Enums
{
    public enum ApartmentStatus
    {
        Available = 1,
        Occupied = 2,
        UnderMaintenance = 3,
        Inactive = 4
    }
}
