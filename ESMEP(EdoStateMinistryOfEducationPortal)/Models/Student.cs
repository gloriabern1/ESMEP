namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            ExaminationRegistereds = new HashSet<ExaminationRegistered>();
        }

        public int StudentId { get; set; }

        public int SchoolId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string DateOfBirth { get; set; }
        [Required]
        [StringLength(1)]
        public string Sex { get; set; }
        [Required]
        public string Address { get; set; }
        public int LocalGovernmentID { get; set; }
        public string RegNumber { get; set; }
        public string PassportUrl { get; set; }
        public string ExamYear { get; set; }
        public int? StudentGuardianDetialID { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [StringLength(50)]
        public string DateModified { get; set; }
        [Required]
        [StringLength(50)]
        public string DateCreated { get; set; }
        public bool? DOEApproval { get; set; }

        public bool? TechFee { get; set; }
        public bool? RegistrationFee { get; set; }

        public int? BatchID { get; set; }

        public int SessionId { get; set; }
        public virtual School School { get; set; }
        public virtual Session Session { get; set; }
        public virtual StudentGuardianDetial StudentGuardianDetial { get; set; }
        public virtual LocalGovernment LocalGovernment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExaminationRegistered> ExaminationRegistereds { get; set; }
    }
}
