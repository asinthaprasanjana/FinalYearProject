using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("TestStatus")]
    public class TestStatus : BaseEntity
    {
        public TestStatus()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusID { get; set; }

        [Required]
        [ForeignKey("TestTemplateAttribute")]
        public int AttributeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        public virtual TestTemplateAttribute TestTemplateAttribute { get; set; }
    }
}
