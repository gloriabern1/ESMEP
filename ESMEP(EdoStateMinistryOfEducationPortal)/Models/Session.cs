namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Session
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Session()
        {
            ExaminationRegistereds = new HashSet<ExaminationRegistered>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public bool Activated { get; set; }
        public bool Is_Current { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExaminationRegistered> ExaminationRegistereds { get; set; }
    }
}
