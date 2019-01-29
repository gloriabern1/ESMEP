namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExaminationRegistered
    {
        [Key]
        public int RegistrationId { get; set; }

        public int SchoolId { get; set; }

        public string SchoolCode { get; set; }

        public int StudentId { get; set; }

        public int ExamId { get; set; }

        public int? SessionId { get; set; }

        public int SubjectId { get; set; }

        [Required]
        [StringLength(5)]
        public string SubjectCode { get; set; }

        public int? CategoryId { get; set; }

        public int? SchoolTypeId { get; set; }

        public string StudentRegNum { get; set; }

        public decimal? CAScore { get; set; }

        public decimal? ExamScore { get; set; }

        public decimal? TotalScore { get; set; }

        [StringLength(2)]
        public string Grade { get; set; }

        public bool? Status { get; set; }

        public bool? Attendance { get; set; }

        public string Remarks { get; set; }

        public DateTime DateRegistered { get; set; }
           
        public bool? IsProcessed { get; set; }

        [StringLength(50)]
        public string DateProcessed { get; set; }

        [StringLength(50)]
        public string ProcessedBy { get; set; }

        public DateTime? DateOfExam { get; set; }

        public string CreateBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Examination Examination { get; set; }

        public virtual School School { get; set; }

        public virtual Session Session { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
