
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    public partial class SchoolApproval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Required]
        public int YearId { get; set; }


        [Required]
        public int SchoolId { get; set; }

        
        public int? BatchId { get; set; }      

        [Required]
        public bool Activated { get; set; }
        
        public int? ReceiptID { get; set; }

        public DateTime DateApproved { get; set; }

     
    }
}