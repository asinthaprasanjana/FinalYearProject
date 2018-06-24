using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Max.MedicalLab.Data.Entity
{
    public class MedLabContext : DbContext
    {
        /// <summary>
        /// MaxMedicalLabDB is the database name.
        /// MediLabContext class represents entity set that is used for create,delete and update
        /// operations
        /// </summary>
        public MedLabContext() : base("MaxMedidata") 
        {            
        }        

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<PatientTest> PatientTests { get; set; }

        public DbSet<TestTemplateAttribute> TestTemplateAttributes { get; set; }

        public DbSet<PatientVisit> PatientVisits { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<TestResult> TestResults { get; set; }

        public DbSet<TestStatus> TestStatuses { get; set; }

        public DbSet<TestTemplate> TestTemplates { get; set; }

        /// <summary>
        /// OnmodelCreating gives access to a ModelBuilder Instence that we can use to confogure the model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
