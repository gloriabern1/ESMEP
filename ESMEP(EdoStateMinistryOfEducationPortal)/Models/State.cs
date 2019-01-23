namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class State
    {
        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string STATE_NAME { get; set; }

        [Required]
        [StringLength(2)]
        public string COUNTRY_ID { get; set; }

        public bool ACTIVATED { get; set; }
    }
}
