namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuInRole
    {
        [Key]
        public int Menu_In_RoleID { get; set; }

        public int MenuSubId { get; set; }

        public int RoleId { get; set; }

        public virtual MenuSub MenuSub { get; set; }
    }
}
