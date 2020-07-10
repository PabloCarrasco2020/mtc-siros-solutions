using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Enums;
using Transversal.Common.Helper;

namespace Application.Core
{
    public class LogApplication : ILogApplication
    {
        private readonly AppSettings.Logs _settings;
        private readonly IEmailApplication _emailApplication;

        public LogApplication(IOptions<AppSettings.Logs> settings, IEmailApplication emailApplication)
        {
            this._settings = settings.Value;
            this._emailApplication = emailApplication;
        }

        public async Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, string sMessage)
        {
            try
            {
                var oResponse = new Response<string>();
                oResponse.IsSuccess = false;

                if (!Directory.Exists(this._settings.Path))
                    Directory.CreateDirectory(this._settings.Path);

                DateTime dtCurrentDate = DateTime.Now;

                if (oLogType == EnumLogType.TEXT || oLogType == EnumLogType.TEXT_N_EMAIL)
                {
                    string sNewPathFolder = $@"{this._settings.Path}\LOG_{dtCurrentDate.Year}";

                    if (!Directory.Exists(sNewPathFolder))
                        Directory.CreateDirectory(sNewPathFolder);

                    string sFilename = $@"{sNewPathFolder}\LOG_{dtCurrentDate.Day.ToString("00")}-{dtCurrentDate.Month.ToString("00")}-{dtCurrentDate.Year}.log";
                    File.AppendAllText(sFilename, sMessage, Encoding.UTF8);
                }

                if (oLogType == EnumLogType.EMAIL || oLogType == EnumLogType.TEXT_N_EMAIL)
                {
                    try
                    {
                        var oEmail = new EmailDto.Request();
                        oEmail.sSendTo = this._settings.EmailSendTo;
                        oEmail.sReplyTo = this._settings.EmailReplyTo;
                        oEmail.sSubject = string.Format(this._settings.EmailSubject, sName);
                        oEmail.sMessage = sMessage.Replace("\r\n", "<br>");

                        _ = this._emailApplication.SendEmail(oEmail);
                    }
                    catch (Exception ex) 
                    {
                        _= this.SetLog(EnumLogType.TEXT, EnumLogCategory.ERROR, "LogApplication-SetLogEmail", ex);
                    }
                }

                oResponse.IsSuccess = true;
                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, Exception oException)
        {
            try
            {
                string sLogType = "UNKNOWN";
                if (oLogCategory == EnumLogCategory.INFORMATION)
                    sLogType = "INFORMATION";
                else if (oLogCategory == EnumLogCategory.WARNING)
                    sLogType = "WARNING";
                else if (oLogCategory == EnumLogCategory.ERROR)
                    sLogType = "ERROR";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"---------------------------------------------");
                sb.AppendLine($"[Type]: {sLogType}");
                sb.AppendLine($"[Date]: {DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}");
                sb.AppendLine($"[Name]: {sName}");
                sb.AppendLine($"[Message]: {oException.Message}");
                sb.AppendLine($"[StackTrace]: {oException.StackTrace}");
                sb.AppendLine($"[InnerException]: {oException.InnerException}");

                return this.SetLog(oLogType, oLogCategory, sName, sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region EXTRAS CONFIGURADOS

        public Task<Response<string>> SetLogInfo(string sName, string sMessage)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.INFORMATION, sName, sMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLogInfo(string sName, Exception oException)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.INFORMATION, sName, oException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLogWarning(string sName, string sMessage)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.WARNING, sName, sMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLogWarning(string sName, Exception oException)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.WARNING, sName, oException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLogError(string sName, string sMessage)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, sName, sMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response<string>> SetLogError(string sName, Exception oException)
        {
            try
            {
                return this.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, sName, oException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
