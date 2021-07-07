using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Services;

namespace EmployeeManagement.Models
{
    public class UserPageModel
    {
        private readonly static IDepartmentRepository departmentRepository = new DepartmentRepository();
        private readonly static IRoleRepository roleRepository = new RoleRepository();

        public int UserId { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserAccount { get; set; }
        public string UserPwd { get; set; }
        public string UserRealName { get; set; }
        public string UserSex { get; set; }
        public string UserPhone { get; set; }
        public string UserPowerList { get; set; }
        public bool? UserStatus { get; set; }
        public DateTime? ReleaseTime { get; set; }


        public static UserPageModel CreateModel(EmUser user)
        {
            UserPageModel result = new UserPageModel
            {
                UserId = user.UserId,
                DepartmentId = user.DepartmentId,
                DepartmentName = departmentRepository.GetDepartment(user.DepartmentId).DepartmentName,
                RoleId = user.RoleId,
                RoleName = roleRepository.GetRole(user.RoleId.Value).RoleName,
                UserAccount = user.UserAccount,
                UserPwd = user.UserPwd,
                UserRealName = user.UserRealName,
                UserSex = user.UserSex,
                UserPhone = user.UserPhone,
                UserPowerList = user.UserPowerList,
                UserStatus = user.UserStatus,
                ReleaseTime = user.ReleaseTime,
            };

            return result;
        }
    }
}