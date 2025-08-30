using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_Management.Domain.AggregateRoots.BManagementRoot
{
    [Table("LeaseAgreements")]
    public class LeaseAgreement : EntityBase
    {
        public string LeaseAgreementCode { get; set; }
        public int ApartmentID { get; set; }
        public int ResidentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentPrice { get; set; }
        public decimal? DepositPrice { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }
    }
}
