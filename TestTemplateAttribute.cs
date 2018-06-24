using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("TestTemplateAttribute")]
    public class TestTemplateAttribute : BaseEntity
    {
        public TestTemplateAttribute()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttrID { get; set; }
        
        [Required]
        [ForeignKey("TestTemplate")]
        public int TemplateID { get; set; }

        [Required]
        [StringLength(250)]
        public string Attribute { get; set; }

        [Required]
        public string PrefferedLimit { get; set; }

        public virtual TestTemplate TestTemplate { get; set; }

        public virtual IList<TestStatus> TestStatus { get; set; } 
    }
}
