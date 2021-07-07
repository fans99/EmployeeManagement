using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    interface IUserRepository
    {
        IEnumerable<EmUser> GetAllUser();

        EmUser GetUser(int id);

        int Insert(EmUser user);

        EmUser Update(EmUser updateUser);

        EmUser UpdateStatus(int userId, bool status);

        EmUser Delete(int id);

        int DeleteMultiple(IEnumerable<int> id);

        IEnumerable<EmUser> Find(string queryInfo);

        EmUser Find(string userAccount, string userPwd);
    }
}
