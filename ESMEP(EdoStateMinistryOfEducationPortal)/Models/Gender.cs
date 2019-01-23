namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gender
    {
        [Key]
        [StringLength(1)]
        public string GENDER_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string GENDER_NAME { get; set; }

        public bool ACTIVATED { get; set; }
    }
}
