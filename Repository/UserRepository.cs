using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
using System.Data.SqlClient;
using System.Configuration;
using Max.MedicalLab.Common.Dto;
using System.Data;
using System.Linq.Expressions;

namespace Max.MedicalLab.Data.Entity.Repository
{
    public class UserRepository:MedLabRepository<User>
    {
        public User GetUser(string username)
        {
          var user = base.context.Users.AsNoTracking().FirstOrDefault(p => p.Username.Equals(username));
          return user;
        }

        
    }
}