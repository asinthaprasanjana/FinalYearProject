using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.AutoMapper;
using AutoMapper;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleManager : MedLabRepository<Role>
    {
        RoleRepository RoleRepo = new RoleRepository();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public RoleDto createRole(Role role)
        {
            MapperConfig.ConfigAutoMapper();

            if (this.IsRoleValid(role))
            {
                role.CreatedDate = DateTime.Now;
                role.CreatedBy = "Administrator";
                role.ModifiedDate = null;
                role.ModifiedBy = string.Empty;

                var saveRole = RoleRepo.Insert(Mapper.Map<Role>(role));
                return Mapper.Map<RoleDto>(saveRole);

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Role not Created ! Validation Failed !");
            }

            return null;
                
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public RoleDto UpdateRole(Role role)
        {
            MapperConfig.ConfigAutoMapper();

            if (role!=null)
            {
                role.CreatedDate = RoleRepo.GetRole(role.RoleID).CreatedDate;
                role.CreatedBy = RoleRepo.GetRole(role.RoleID).CreatedBy;
                role.ModifiedBy = "Administrator";
                role.ModifiedDate = DateTime.Now;

                RoleRepo.Update(Mapper.Map<Role>(role));

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Null Role");
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public RoleDto DeleteRole(Role role)
        {
            MapperConfig.ConfigAutoMapper();

            if (role.RoleID.ToString()!=null)
            {
                int Role = RoleRepo.GetRole(role.RoleID).RoleID;

                if (Role.ToString()!= null)
                {
                    role.CreatedBy = RoleRepo.GetRole(role.RoleID).CreatedBy;
                    role.CreatedDate = RoleRepo.GetRole(role.RoleID).CreatedDate;
                    role.ModifiedBy = RoleRepo.GetRole(role.RoleID).ModifiedBy;
                    role.ModifiedDate = RoleRepo.GetRole(role.RoleID).ModifiedDate;

                    Role DelRole = context.Roles.SingleOrDefault(item => item.RoleID == role.RoleID);
                    context.Roles.Remove(DelRole);
                    context.SaveChanges();

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Role not Exists");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Null Role");
            }
            return null;
        }

        private bool IsRoleValid(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("Role Does not exists");
            }

            if (string.IsNullOrEmpty(role.RoleName))
            {
                throw new ArgumentNullException("Insert Rolename Field!");
            }

            if (string.IsNullOrEmpty(role.Remarks))
            {
                throw new ArgumentNullException("Insert Remarks Field!");
            }

            return true;

        }
    }
}
