using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    interface IRoleRepository
    {
        IEnumerable<EmRole> GetAllRole();

        EmRole GetRole(int id);

        int Insert(EmRole role);

        EmRole Update(EmRole updateRole);

        EmRole Delete(int id);

        int DeleteMultiple(IEnumerable<int> id);

        IEnumerable<EmRole> Find(string roleName);
    }
}
