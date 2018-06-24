using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("TestResult")]
    public class TestResult : BaseEntity
    {
        public TestResult()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("PatientVisit")] 
        public int VisitID { get; set; }

        [Required]     
        public int AttrID { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual PatientVisit PatientVisit { get; set; }

    }
}
