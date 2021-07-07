using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDBEntities context = new EmployeeDBEntities();

        public EmDepartment Delete(string deleteDepartmentId)
        {
            EmDepartment deleteDepartment = context.EmDepartment.SingleOrDefault(p => p.DepartmentId.Equals(deleteDepartmentId));
            if (deleteDepartment == null)
                throw new Exception();

            IEnumerable<EmDepartment> childDepartments = context.EmDepartment.Where(p => p.MotherId.Equals(deleteDepartment.DepartmentId));
            if (childDepartments.Count() > 0)
            {
                foreach (EmDepartment item in childDepartments)
                {
                    Delete(item);
                }
            }

            EmDepartment result = context.EmDepartment.Remove(deleteDepartment);
            context.SaveChanges();
            return result;
        }

        public EmDepartment Delete(EmDepartment deleteDepartment)
        {
            if (deleteDepartment == null)
                throw new Exception();

            IEnumerable<EmDepartment> childDepartments = context.EmDepartment.Where(p => p.MotherId.Equals(deleteDepartment.DepartmentId));
            if (childDepartments.Count() > 0)
            {
                foreach (EmDepartment item in childDepartments)
                {
                    Delete(item);
                }
            }

            EmDepartment result = context.EmDepartment.Remove(deleteDepartment);
            context.SaveChanges();
            return result;
        }

        public IEnumerable<EmDepartment> Find(string departmentName)
        {
            return context.EmDepartment.Where(p => p.DepartmentName.Equals(departmentName));
        }

        public IEnumerable<EmDepartment> GetAllDepartment()
        {
            return context.EmDepartment;
        }

        public EmDepartment GetDepartment(string departmentId)
        {
            return context.EmDepartment.SingleOrDefault(p => p.DepartmentId.Equals(departmentId));
        }

        public int Insert(EmDepartment department)
        {
            if (string.IsNullOrEmpty(department.MotherId))
                department.MotherId = "";
            context.EmDepartment.Add(department);
            int result = context.SaveChanges();
            return result;
        }

        public EmDepartment Update(EmDepartment updateDepartment)
        {
            if (updateDepartment == null)
                return null;
            if (string.IsNullOrEmpty(updateDepartment.MotherId))
                updateDepartment.MotherId = "";
            context.Entry(updateDepartment).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return updateDepartment;
        }
    }
}