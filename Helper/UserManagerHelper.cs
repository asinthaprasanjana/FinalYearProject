using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Business.Core.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class UserManagerHelper:MedLabRepository<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User GetUser(int userID)
        {
            var user = base.context.Users.AsNoTracking().FirstOrDefault(p => p.UserId.Equals(userID));
            return user;
        }
    }
}
