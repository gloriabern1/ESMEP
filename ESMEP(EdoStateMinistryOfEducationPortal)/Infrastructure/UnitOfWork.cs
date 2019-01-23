using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private ESMEPContext myContext;

        private GenericRepository<Subject> SubjectRepo;
        private GenericRepository<School> SchoolRepo;
        private GenericRepository<Examination> ExamRepo;
        private GenericRepository<ExaminationRegistered> ExamRegistrationRepo;
        private GenericRepository<StudentGuardianDetial> studentGuardianRepo;
        private GenericRepository<Student> studentsRepo;
        private GenericRepository<SchoolType> schoolTypeRepo;
        private GenericRepository<Session> SessionRepo;
        private GenericRepository<State> StateRepo;
        private GenericRepository<LocalGovernment> LgaRepo;
        private GenericRepository<Relationship> RelationshipRepo;
        private GenericRepository<Gender> sexRepo;
        private GenericRepository<Category> categoryRepo;
        private GenericRepository<AspNetRole> RoleRepo;
        private GenericRepository<AspNetUser> UserRepo;
        private GenericRepository<AspNetUserClaim> claimRepo;
        private GenericRepository<MenuInRole> menuInRoleRepo;
        private GenericRepository<MenuMain> mainMenuRepo;
        private GenericRepository<MenuSub> meunSubRepo;
        private GenericRepository<Title> titleRepo;
        private GenericRepository<Inspector> inspectorRepo;

        private ESMEPContext Context
        {
            get
            {
                if (myContext == null)
                {
                    return GetDbContext();
                }
                else
                {
                    return myContext;
                }
            }
        }
        public ESMEPContext GetDbContext()
        {
            myContext = new ESMEPContext();
           return myContext;
        }

        public GenericRepository<Subject> Subject
        {
            get { return this.SubjectRepo ?? new GenericRepository<Subject>(Context); }
        }
        public GenericRepository<School> School
        {
            get { return this.SchoolRepo ?? new GenericRepository<School>(Context); }
        }
        public GenericRepository<SchoolType> SchoolType
        {
            get { return this.SchoolType ?? new GenericRepository<SchoolType>(Context); }
        } 
        public GenericRepository<Student> studentData
        {
            get { return this.studentsRepo ?? new GenericRepository<Student>(Context); }
        }
        public GenericRepository<StudentGuardianDetial> GuardianDetails
        {
            get { return this.studentGuardianRepo ?? new GenericRepository<StudentGuardianDetial>(Context); }
        }
        public GenericRepository<Session> session
        {
            get { return this.SessionRepo ?? new GenericRepository<Session>(Context); }
        }
        public GenericRepository<State> state
        {
            get { return this.StateRepo ?? new GenericRepository<State>(Context); }
        }
        public GenericRepository<LocalGovernment> lga
        {
            get { return this.LgaRepo ?? new GenericRepository<LocalGovernment>(Context); }
        }
        public GenericRepository<Relationship> Relationship
        {
            get { return this.RelationshipRepo ?? new GenericRepository<Relationship>(Context); }
        }
        public GenericRepository<Examination> Exam
        {
            get { return this.ExamRepo ?? new GenericRepository<Examination>(Context); }
        }
        public GenericRepository<ExaminationRegistered> ExamRegistered
        {
            get { return this.ExamRegistrationRepo ?? new GenericRepository<ExaminationRegistered>(Context); }
        }
        public GenericRepository<Gender> sex
        {
            get { return this.sexRepo ?? new GenericRepository<Gender>(Context); }
        }
        public GenericRepository<Category> Category
        {
            get { return this.categoryRepo ?? new GenericRepository<Category>(Context); }
        }
        public GenericRepository<AspNetRole> Role
        {
            get { return this.RoleRepo ?? new GenericRepository<AspNetRole>(Context); }
        }
        public GenericRepository<AspNetUser> AspUser
        {
            get { return this.UserRepo ?? new GenericRepository<AspNetUser>(Context); }
        }
        public GenericRepository<MenuSub> MenuSub
        {
            get { return this.meunSubRepo ?? new GenericRepository<MenuSub>(Context); }
        }
        public GenericRepository<MenuMain> MenuMain
        {
            get { return this.mainMenuRepo ?? new GenericRepository<MenuMain>(Context); }
        }
        public GenericRepository<MenuInRole> MenuInRole
        {
            get { return this.menuInRoleRepo ?? new GenericRepository<MenuInRole>(Context); }
        }
        public GenericRepository<Title> Title
        {
            get { return this.titleRepo ?? new GenericRepository<Title>(Context); }
        }
        public GenericRepository<Inspector> inspector
        {
            get { return this.inspectorRepo ?? new GenericRepository<Inspector>(Context);  }
        }

        public void Save()
        {
            try
            {
                myContext.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (myContext != null)
                    {
                        myContext.Dispose();
                    }
                }
                if (Context != null)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                    }
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
