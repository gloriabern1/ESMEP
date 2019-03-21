namespace ESMEP_EdoStateMinistryOfEducationPortal_.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ESMEPContext : DbContext
    {
        public ESMEPContext()
            : base("name=ESMEPContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ExaminationRegistered> ExaminationRegistereds { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<LocalGovernment> LocalGovernments { get; set; }
        public virtual DbSet<MenuInRole> MenuInRoles { get; set; }
        public virtual DbSet<MenuMain> MenuMains { get; set; }
        public virtual DbSet<MenuSub> MenuSubs { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentGuardianDetial> StudentGuardianDetials { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<SchoolQuota> SchoolQuotas { get; set; }
        public virtual DbSet<SchoolApproval> SchoolApproval { get; set; }
        public virtual DbSet<ApprovalReceipt> ApprovalReceipt { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.SubjectCode)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.StudentRegNum)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.CAScore)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.ExamScore)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.TotalScore)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.Grade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.DateProcessed)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.ProcessedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationRegistered>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Examination>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Examination>()
                .Property(e => e.Fee)
                .IsFixedLength();

            modelBuilder.Entity<Examination>()
                .Property(e => e.ExamCode)
                .IsUnicode(false);

            modelBuilder.Entity<Examination>()
                .HasMany(e => e.ExaminationRegistereds)
                .WithRequired(e => e.Examination)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.GENDER_ID)
                .IsFixedLength();

            modelBuilder.Entity<Gender>()
                .Property(e => e.GENDER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.CIEName)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Inspector>()
                .Property(e => e.ModifiedOn)
                .IsUnicode(false);

            modelBuilder.Entity<LocalGovernment>()
                .Property(e => e.LocalGovernment1)
                .IsUnicode(false);

            modelBuilder.Entity<LocalGovernment>()
                .Property(e => e.StateId)
                .IsFixedLength();

            modelBuilder.Entity<LocalGovernment>()
                .HasMany(e => e.Inspectors)
                .WithRequired(e => e.LocalGovernment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocalGovernment>()
                .HasMany(e => e.Schools)
                .WithRequired(e => e.LocalGovernment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuMain>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MenuMain>()
                .Property(e => e.ICONS)
                .IsUnicode(false);

            modelBuilder.Entity<MenuMain>()
                .HasMany(e => e.MenuSubs)
                .WithRequired(e => e.MenuMain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuSub>()
                .Property(e => e.MenuTitle)
                .IsUnicode(false);

            modelBuilder.Entity<MenuSub>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<MenuSub>()
                .HasMany(e => e.MenuInRoles)
                .WithRequired(e => e.MenuSub)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Relationship>()
                .Property(e => e.RELATIONSHIP_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.MobileNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<School>()
                .Property(e => e.NameOfPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.ExaminationRegistereds)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SchoolType>()
                .Property(e => e.SchoolType1)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.STATE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.DateOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PassportUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.DateModified)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.DateCreated)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.ExaminationRegistereds)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentGuardianDetial>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGuardianDetial>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGuardianDetial>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGuardianDetial>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.ExaminationRegistereds)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Name)
                .IsUnicode(false);

     
        }
    }
}
