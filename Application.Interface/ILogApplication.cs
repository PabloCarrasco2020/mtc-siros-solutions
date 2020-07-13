using Application.Dto;
using System;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Enums;

namespace Application.Interface
{
    public interface ILogApplication
    {
        Task<Response<string>> SetLogText(EnumLogCategory oLogCategory, string sName, string sMessage);
        Task<Response<string>> SetLogText(EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData);

        Task<Response<string>> SetLogEmail(EnumLogCategory oLogCategory, string sName, string sMessage);
        Task<Response<string>> SetLogEmail(EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData);

        Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, string sMessage);
        Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData);
    }
}
