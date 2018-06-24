using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("TestTemplate")]
    public class TestTemplate : BaseEntity
    { 
        public TestTemplate()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestTemplateId { get; set; }

        [Required]
        [StringLength(250)]
        public string TemplateName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual IList<PatientTest> PatientTests { get; set; }

        public virtual IList<TestTemplateAttribute> TestTemplateAttributes { get; set; }
    }
}
