using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    public class SchoolQuota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int QuotaAssigned { get; set; }
        public int? QuotaUsed { get; set; }
        public int SessionId { get; set; }
        public string Year { get; set; }
        public virtual School School { get; set; }
        public virtual Session Session { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}