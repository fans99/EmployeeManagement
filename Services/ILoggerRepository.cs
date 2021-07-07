using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    interface ILoggerRepository
    {
        #region 登录日志
        int InsertToLoginLog(EmLoginLog newLoginLog);

        EmLoginLog GetToLoginLog(int loginLogId);

        IEnumerable<EmLoginLog> GetAllToLoginLog();

        IEnumerable<EmLoginLog> FindToLoginLog(string loginIp);

        IEnumerable<EmLoginLog> FindToLoginLog(DateTime startTime, DateTime endTime);

        EmLoginLog DeleteToLoginLog(int deleteLoginLogId);

        int DeleteAllToLoginLog();
        #endregion

        #region 异常日志
        int InsertToException(EmException newException);

        EmException GetToException(int exceptionId);

        IEnumerable<EmException> GetAllToException();

        IEnumerable<EmException> FindToException(string ExceptionIp);

        IEnumerable<EmException> FindToException(DateTime startTime, DateTime endTime);

        EmException DeleteToException(int deleteExceptionId);

        int DeleteAllToException();
        #endregion

    }
}
