using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
namespace Max.MedicalLab.Data.Entity.Repository
{
    public class RoleRepository:MedLabRepository<Role>
    {
        public Role GetRole(int roleID)
        {
            var role = base.context.Roles.AsNoTracking().FirstOrDefault(p => p.RoleID.Equals(roleID));
            return role;
        }
    }
}
