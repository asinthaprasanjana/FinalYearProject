using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("Doctor")]
    public class Doctor : BaseEntity
    {
        public Doctor()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]  
        public string DoctorName { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorSpeciality { get; set; }

        public virtual IList<PatientVisit> PatientVisits { get; set; } 

        public virtual IList<PatientTest> PatientTests { get; set; } 
    }
}
