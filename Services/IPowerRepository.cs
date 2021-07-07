using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    interface IPowerRepository
    {
        EmPower GetPower(string powerId);

        IEnumerable<EmPower> GetAllPower();

        IEnumerable<EmPower> GetAllPower(int userId);

        EmPower CreatePower(EmPower newPower);

        EmPower DeletePower(string deletePowerId);
        
        IEnumerable<EmPower> GetPowerInUser(int userId);

        IEnumerable<EmPower> GetPowerInRole(int roleId);

        IEnumerable<EmPower> GetPowerChlids(EmPower emPower);

        int SetPowerToUser(int userId, IEnumerable<string> collection);

        int SetPowerToRole(int roleId, IEnumerable<string> collection);
    }
}