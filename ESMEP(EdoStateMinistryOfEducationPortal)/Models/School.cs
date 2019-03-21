namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            ExaminationRegistereds = new HashSet<ExaminationRegistered>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MobileNo { get; set; }

        public int? CategoryId { get; set; }

        public int SchoolTypeId { get; set; }

        public int LocalGovernmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIncorporation { get; set; }

        [Required]
        public string NameOfPrincipal { get; set; }
        public bool? IsQuotaAssigned { get; set; }
        [Required]
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExaminationRegistered> ExaminationRegistereds { get; set; }

        public virtual LocalGovernment LocalGovernment { get; set; }

        public virtual SchoolType SchoolType { get; set; }
    }
}
