using BM_Management.Domain.AggregateRoots.BManagementRoot.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Employees")]
    public class Employee
    {
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    }
}
