using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Services
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly EmployeeDBEntities context = new EmployeeDBEntities();

        public int DeleteAllToException()
        {
            return context.Database.ExecuteSqlCommand("truncate table EmException");
        }

        public int DeleteAllToLoginLog()
        {
            return context.Database.ExecuteSqlCommand("truncate table EmLoginLog");
        }

        public EmException DeleteToException(int deleteExceptionId)
        {
            EmException deleteException = context.EmException.Find(deleteExceptionId);
            EmException result = context.EmException.Remove(deleteException);
            context.SaveChanges();
            return result;
        }

        public EmLoginLog DeleteToLoginLog(int deleteLoginLogId)
        {
            EmLoginLog deleteLoginLog = context.EmLoginLog.Find(deleteLoginLogId);
            EmLoginLog result = context.EmLoginLog.Remove(deleteLoginLog);
            context.SaveChanges();
            return result;
        }

        public IEnumerable<EmException> FindToException(string ExceptionIp)
        {
            return context.EmException.Where(p => p.ExceptionIp.Equals(ExceptionIp));
        }

        public IEnumerable<EmException> FindToException(DateTime startTime, DateTime endTime)
        {
            return context.EmException.Where(p => p.ExceptionTime.Value > startTime && p.ExceptionTime.Value < endTime);
        }

        public IEnumerable<EmLoginLog> FindToLoginLog(string loginIp)
        {
            return context.EmLoginLog.Where(p => p.LoginIp.Equals(loginIp));
        }

        public IEnumerable<EmLoginLog> FindToLoginLog(DateTime startTime, DateTime endTime)
        {
            return context.EmLoginLog.Where(p => p.LoginTime.Value > startTime && p.LoginTime.Value < endTime);
        }

        public IEnumerable<EmException> GetAllToException()
        {
            return context.EmException;
        }

        public IEnumerable<EmLoginLog> GetAllToLoginLog()
        {
            return context.EmLoginLog;
        }

        public EmException GetToException(int exceptionId)
        {
            return context.EmException.Find(exceptionId);
        }

        public EmLoginLog GetToLoginLog(int loginLogId)
        {
            return context.EmLoginLog.Find(loginLogId);
        }

        public int InsertToException(EmException newException)
        {
            context.EmException.Add(newException);
            return context.SaveChanges();
        }

        public int InsertToLoginLog(EmLoginLog newLoginLog)
        {
            context.EmLoginLog.Add(newLoginLog);
            return context.SaveChanges();
        }
    }
}