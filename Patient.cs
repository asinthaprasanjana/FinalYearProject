using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("Patient")]
    public class Patient : BaseEntity
    {
        public Patient()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        public static explicit operator int(Patient v)
        {
            throw new NotImplementedException();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string ContactNo { get; set; }
    
        public virtual IList<PatientVisit> PatientVisits { get; set; } 
    }
}
