namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Relationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RELATIONSHIP_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RELATIONSHIP_NAME { get; set; }

        public bool ACTIVATED { get; set; }
    }
}
