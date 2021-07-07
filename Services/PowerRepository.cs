using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
using System.Text;

namespace EmployeeManagement.Services
{
    public class PowerRepository : IPowerRepository
    {
        private readonly EmployeeDBEntities context = new EmployeeDBEntities();

        public EmPower GetPower(string powerId)
        {
            return context.EmPower.SingleOrDefault(p => p.PowerId.Equals(powerId));
        }

        public IEnumerable<EmPower> GetAllPower()
        {
            return context.EmPower;
        }

        public IEnumerable<EmPower> GetAllPower(int userId)
        {
            var result = (from user in context.EmUser
                         join role in context.EmRole on user.RoleId equals role.RoleId
                         where user.UserId == userId
                         select new
                         {
                             user.UserPowerList,
                             role.RolePowerList
                         }).FirstOrDefault();

            IEnumerable<string> powerList = result.RolePowerList.Split(' ');
            powerList = powerList.Union(result.UserPowerList.Split(' '));

            List<EmPower> powerResult = new List<EmPower>();
            AddRecursive(powerResult, context.EmPower.Where(p => powerList.Contains(p.PowerId)));
            return powerResult;
        }

        public EmPower CreatePower(EmPower newPower)
        {
            EmPower result = context.EmPower.Add(newPower);
            context.SaveChanges();
            return result;
        }

        public EmPower DeletePower(string deletePowerId)
        {
            EmPower deletePower = context.EmPower.SingleOrDefault(p => p.PowerId.Equals(deletePowerId));
            if (deletePower == null)
                throw new Exception("找不到该权限");

            IEnumerable<EmPower> childPowers = context.EmPower.Where(p => p.MotherId.Equals(deletePower.PowerId));
            if (childPowers.Count() > 0)
            {
                foreach (EmPower item in childPowers)
                {
                    DeletePower(item);
                }
            }

            EmPower result = context.EmPower.Remove(deletePower);
            context.SaveChanges();
            return result;
        }

        public EmPower DeletePower(EmPower deletePower)
        {
            if (deletePower == null)
                throw new Exception("权限不能为空");

            IEnumerable<EmPower> childPowers = context.EmPower.Where(p => p.MotherId.Equals(deletePower.PowerId));
            if (childPowers.Count() > 0)
            {
                foreach (EmPower item in childPowers)
                {
                    DeletePower(item);
                }
            }

            EmPower result = context.EmPower.Remove(deletePower);
            context.SaveChanges();
            return result;
        }

        public IEnumerable<EmPower> GetPowerChlids(EmPower emPower)
        {
            IEnumerable<EmPower> result = context.EmPower.Where(p => p.MotherId.Equals(emPower.PowerId));
            return result.Count() > 0 ? result : null;
        }

        public IEnumerable<EmPower> GetPowerInUser(int userId)
        {
            EmUser result = context.EmUser.SingleOrDefault(p => p.UserId == userId);
            if (result == null)
                throw new Exception("无法找到该用户");

            string[] powerList = result.UserPowerList.Split(' ');
            List<EmPower> powerResult = new List<EmPower>();
            AddRecursive(powerResult, context.EmPower.Where(p => powerList.Contains(p.PowerId)));
            return powerResult;
        }

        public IEnumerable<EmPower> GetPowerInRole(int roleId)
        {
            EmRole result = context.EmRole.SingleOrDefault(p => p.RoleId == roleId);
            if (result == null)
                throw new Exception("无法找到该角色");

            string[] powerList = result.RolePowerList.Split(' ');
            List<EmPower> powerResult = new List<EmPower>();
            AddRecursive(powerResult, context.EmPower.Where(p => powerList.Contains(p.PowerId)));
            return powerResult;
        }   

        public int SetPowerToRole(int roleId, IEnumerable<string> collection)
        {
            EmRole result = context.EmRole.SingleOrDefault(p => p.RoleId == roleId);
            if (result == null)
                throw new Exception("找不到该角色");

            result.RolePowerList = PowerListToString(collection);
            return context.SaveChanges();
        }

        public int SetPowerToUser(int userId, IEnumerable<string> collection)
        {
            EmUser result = context.EmUser.SingleOrDefault(p => p.RoleId == userId);
            if (result == null)
                throw new Exception("找不到该用户");

            result.UserPowerList = PowerListToString(collection);
            return context.SaveChanges();
        }

        private string PowerListToString(IEnumerable<string> powerList)
        {
            StringBuilder result = new StringBuilder();
            foreach (string item in powerList)
            {
                result.Append(item);
                result.Append(' ');
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        private void AddRecursive(List<EmPower> list, IEnumerable<EmPower> collection)
        {
            foreach (EmPower item in collection)
            {
                list.Add(item);

                IEnumerable<EmPower> childs = GetPowerChlids(item);
                if (childs != null)
                    AddRecursive(list, childs);
            }
        }
    }
}