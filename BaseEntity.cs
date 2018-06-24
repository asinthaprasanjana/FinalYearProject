using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    public class BaseEntity
    {
        public BaseEntity() //applicable for all classes//
        {
        }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

       
        public DateTime? ModifiedDate { get; set; }

        
        public string ModifiedBy { get; set; }
    }
}
