using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot.Enums
{
    public enum InvoiceStatus
    {
        Unpaid = 0,
        Paid = 1,
        Overdue = 2
    }
}
