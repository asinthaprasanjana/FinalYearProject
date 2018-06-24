using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("PatientTest")]
    public class PatientTest : BaseEntity
    {
        public PatientTest()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientTestID { set; get; }

        [Required]
        [ForeignKey("PatientVisit")] 
        public int VisitID { get; set; }

        [Required]
        [ForeignKey("TestTemplate")] 
        public int TemplateID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ApprovedBy { get; set; }

        public DateTime ApprovedDate { get; set; }

        public virtual PatientVisit PatientVisit { get; set; }

        public virtual TestTemplate TestTemplate { get; set; }
    }
}
