using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeDBEntities context = new EmployeeDBEntities();

        public int Insert(EmUser user)
        {
            if (user == null)
                return -1;

            string sql = @"insert into EmUser(DepartmentId,RoleId,UserAccount,UserPwd,UserRealName,UserSex,UserPhone,UserPowerList)
                    values(@DepartmentId, @RoleId, @UserAccount, @UserPwd, @UserRealName, @UserSex, @UserPhone, @UserPowerList)";
            if (string.IsNullOrWhiteSpace(user.UserPowerList))
                user.UserPowerList = "";
            SqlParameter[] param =
            {
                    new SqlParameter("@DepartmentId", user.DepartmentId),
                    new SqlParameter("@RoleId", user.RoleId),
                    new SqlParameter("@UserAccount", user.UserAccount),
                    new SqlParameter("@UserPwd", user.UserPwd),
                    new SqlParameter("@UserRealName", user.UserRealName),
                    new SqlParameter("@UserSex", user.UserSex),
                    new SqlParameter("@UserPhone", user.UserPhone),
                    new SqlParameter("@UserPowerList", user.UserPowerList),
                };
            int result = context.Database.ExecuteSqlCommand(sql, param);
            if (result == 1)
                context.SaveChanges();
            return result;
        }

        public EmUser Delete(int id)
        {
            EmUser deleteUser = context.EmUser.Find(id);
            if (deleteUser != null)
                deleteUser = context.EmUser.Remove(deleteUser);
            else
                return null;

            context.SaveChanges();
            return deleteUser;
        }

        public IEnumerable<EmUser> Find(string queryInfo)
        {
            List<EmUser> result = new List<EmUser>();
            foreach (EmUser item in context.EmUser)
            {
                if (item.RoleId.ToString().Contains(queryInfo))
                    result.Add(item);
                else if (item.UserAccount.Contains(queryInfo))
                    result.Add(item);
                else if (item.UserId.ToString().Contains(queryInfo))
                    result.Add(item);
                else if (item.UserPhone.ToString().Contains(queryInfo))
                    result.Add(item);
                else if (item.UserSex.Contains(queryInfo))
                    result.Add(item);
                else if (item.UserRealName.Contains(queryInfo))
                    result.Add(item);
                else if (item.DepartmentId.Contains(queryInfo))
                    result.Add(item);
            }
            return result;
        }

        public EmUser Find(string userAccount, string userPwd)
        {
            return context.EmUser.SingleOrDefault(p => p.UserAccount.Equals(userAccount) && p.UserPwd.Equals(userPwd));
        }

        public IEnumerable<EmUser> GetAllUser()
        {
            return context.EmUser;
        }

        public EmUser GetUser(int id)
        {
            return context.EmUser.SingleOrDefault(p => p.UserId == id);
        }

        public EmUser Update(EmUser updateUser)
        {
            if (updateUser == null)
                return null;
            if (string.IsNullOrWhiteSpace(updateUser.UserPowerList))
                updateUser.UserPowerList = "";

            EmUser user = context.EmUser.Find(updateUser.UserId);
            if (user == null)
                throw new Exception("找不到用户");
            context.EmUser.Attach(user);
            user.DepartmentId = updateUser.DepartmentId;
            user.RoleId = updateUser.RoleId;
            user.UserAccount = updateUser.UserAccount;
            user.UserPhone = updateUser.UserPhone;
            user.UserSex = updateUser.UserSex;
            user.UserRealName = updateUser.UserRealName;
            user.UserPowerList = updateUser.UserPowerList;
            context.SaveChanges();
            return updateUser;
        }

        public EmUser UpdateStatus(int userId, bool status)
        {
            EmUser user = context.EmUser.SingleOrDefault(p => p.UserId == userId);
            if (user == null)
                throw new Exception("找不到用户");
            context.EmUser.Attach(user);
            user.UserStatus = status;
            context.SaveChanges();
            return user;
        }

        public int DeleteMultiple(IEnumerable<int> id)
        {
            foreach (int i in id)
            {
                EmUser deleteUser = context.EmUser.SingleOrDefault(p => p.UserId == i);
                if (deleteUser != null)
                    context.EmUser.Remove(deleteUser);
            }
            return context.SaveChanges();
        }
    }
}