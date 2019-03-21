namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examination()
        {
            ExaminationRegistereds = new HashSet<ExaminationRegistered>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Fee { get; set; }
        [Required]
        [StringLength(5)]
        public string ExamCode { get; set; }
        public int SessionID { get; set; }
        public string Year { get; set; }
        public int? CategoryId { get; set; }
        public bool Activated { get; set; }
        public virtual Session Session { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExaminationRegistered> ExaminationRegistereds { get; set; }
    }
}
