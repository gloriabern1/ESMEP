using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels
{
    public class StudentViewModel
    {
        public long StudentId { get; set; }
        public long SchoolId { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string schoolName { get; set; }

    }
}