using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    public partial class ApprovalReceipt
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ApprovalId { get; set; }
       
        [Required]
        public string CIE { get; set; }

        public string UnitAmount { get; set; }
        public int NoOfStudents { get; set; }
        public string TotalAmount { get; set; }
        public string PrincipalName { get; set; }
        public string SchoolAddress { get; set; }

        public DateTime Date_Generated { get; set; }
        public string ReceiptNo { get; set; }
        public bool Activated { get; set; }

    }
}