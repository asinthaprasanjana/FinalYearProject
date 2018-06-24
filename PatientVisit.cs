using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("PatientVisit")]
    public class PatientVisit:BaseEntity
    {
        public PatientVisit()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientVisitId { get; set; }

        [Required]
        [ForeignKey("Patient")]  
        public int PatientID { get; set; }

        [Required]
        public DateTime ArriveDate { get; set; }

        [Required]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Required]
        [ForeignKey("Doctor")] 
        public int DoctorID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
      

        public virtual Patient Patient { get; set; } 

        public virtual Doctor Doctor { get; set; }

        public virtual User User { get; set; }

        public virtual IList<TestResult> TestResults { get; set; }
    }
}
