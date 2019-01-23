using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels
{
    public class ExamDetailViewModel
    {
        public int ExamId { get; set; }
        public string ExamCode { get; set; }
        public string Fee { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
    }
}