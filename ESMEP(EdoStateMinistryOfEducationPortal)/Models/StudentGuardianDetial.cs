namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentGuardianDetial
    {
        public int ID { get; set; }

        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public int RelationShip { get; set; }
    }
}
