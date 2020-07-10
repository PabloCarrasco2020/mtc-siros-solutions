using Application.Dto;
using System;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Enums;

namespace Application.Interface
{
    public interface ILogApplication
    {
        Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, string sMessage);
        Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, Exception oException);
        
        Task<Response<string>> SetLogInfo(string sName, string sMessage);
        Task<Response<string>> SetLogInfo(string sName, Exception oException);

        Task<Response<string>> SetLogWarning(string sName, string sMessage);
        Task<Response<string>> SetLogWarning(string sName, Exception oException);

        Task<Response<string>> SetLogError(string sName, string sMessage);
        Task<Response<string>> SetLogError(string sName, Exception oException);
    }
}
