using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    interface IDepartmentRepository
    {
        EmDepartment GetDepartment(string departmentId);

        IEnumerable<EmDepartment> GetAllDepartment();

        int Insert(EmDepartment department);

        EmDepartment Update(EmDepartment updateDepartment);

        EmDepartment Delete(string deleteDepartmentId);

        IEnumerable<EmDepartment> Find(string departmentName);
    }
}