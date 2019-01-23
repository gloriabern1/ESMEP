namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuSub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuSub()
        {
            MenuInRoles = new HashSet<MenuInRole>();
        }

        public int MenuSubId { get; set; }

        public int MenuMainId { get; set; }

        [StringLength(50)]
        public string MenuTitle { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        public bool Activated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuInRole> MenuInRoles { get; set; }

        public virtual MenuMain MenuMain { get; set; }
    }
}
