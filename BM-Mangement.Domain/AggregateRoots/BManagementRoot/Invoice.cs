using BM_Management.Domain.AggregateRoots.BManagementRoot.Enums;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("Invoices")]
    public class Invoice : EntityBase
    {
        public string InvoiceCode { get; set; }
        public int LeaseAgreementID { get; set; }
        public int ResidentID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal ElectricityBill { get; set; }
        public decimal WaterBill { get; set; }
        public decimal ManagementFee { get; set; }
        public decimal OtherServices { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
    }
}
