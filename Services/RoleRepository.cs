using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EmployeeDBEntities context = new EmployeeDBEntities();

        public int Insert(EmRole role)
        {
            if (role != null)
            {
                string sql = @"insert into EmRole(RoleName,RoleRemark,RolePowerList)
                                values(@RoleName,@RoleRemark,@RolePowerList)";
                SqlParameter[] param =
                {
                    new SqlParameter("@RoleName", role.RoleName),
                    new SqlParameter("@RoleRemark", role.RoleRemark),
                    new SqlParameter("@RolePowerList", role.RolePowerList)
                };
                int result = context.Database.ExecuteSqlCommand(sql, param);
                
                if (result == 1)
                    context.SaveChanges();

                return result;
            }
                
            return -1;
        }

        public EmRole Delete(int id)
        {
            EmRole deleteRole = context.EmRole.Find(id);
            if (deleteRole != null)
                deleteRole = context.EmRole.Remove(deleteRole);
            else
                return null;

            context.SaveChanges();
            return deleteRole;
        }

        public IEnumerable<EmRole> Find(string roleName)
        {
            return context.EmRole.Where(p => p.RoleName.Equals(roleName));
        }

        public IEnumerable<EmRole> GetAllRole()
        {
            return context.EmRole;
        }

        public EmRole GetRole(int id)
        {
            return context.EmRole.SingleOrDefault(p => p.RoleId == id);
        }

        public EmRole Update(EmRole updateRole)
        {
            if (updateRole == null)
                return null;
            EmRole role = context.EmRole.Find(updateRole.RoleId);
            context.EmRole.Attach(role);
            role.RoleName = updateRole.RoleName;
            role.RolePowerList = updateRole.RolePowerList;
            role.RoleRemark = updateRole.RoleRemark;
            context.SaveChanges();
            return updateRole;
        }

        public int DeleteMultiple(IEnumerable<int> id)
        {
            foreach (int i in id)
            {
                EmRole deleteRole = context.EmRole.SingleOrDefault(p => p.RoleId == i);
                if (deleteRole != null)
                    context.EmRole.Remove(deleteRole);
            }

            return context.SaveChanges();
        }
    }
}