using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace EmployeeManagement.CustomAuthorize
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(int id, string name)
        {
            Id = id;
            Name = name;
            IsAuthenticated = true;
        }

        public int Id { get; }

        public string Name { get; }

        public bool IsAuthenticated { get; }

        public string AuthenticationType { get; }
    }

    public class ApplicationUser : IPrincipal
    {
        public ApplicationUser(int id, string name)
        {
            Identity = new UserIdentity(id, name);
        }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}