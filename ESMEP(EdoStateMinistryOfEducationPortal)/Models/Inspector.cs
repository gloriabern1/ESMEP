namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inspector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string CIEName { get; set; }

        public int LocalGovernmentId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedOn { get; set; }

        public virtual LocalGovernment LocalGovernment { get; set; }
    }
}
