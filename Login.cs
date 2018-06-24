using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.EntityManager
{
    [Table("Login")]
    public class Login : BaseEntity
    {
        public Login()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime LoggedDateTime { get; set; }

        [Required]
        public string MachineID { get; set; }

        [Required]
        public decimal StartingCash { get; set; }
        
        public DateTime? LoggedOutDateTime { get; set; }

        [Required]
        public decimal EndCash { get; set; }

        public virtual User User { get; set; }
    }
}
