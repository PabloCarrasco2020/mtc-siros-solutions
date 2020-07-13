using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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


        #region PRINCIPALES (STRING MESSAGE)

        public async Task<Response<string>> SetLogText(EnumLogCategory oLogCategory, string sName, string sMessage)
        {
            var oResponse = new Response<string>();
            try
            {
                if (!Directory.Exists(this._settings.Path))
                    Directory.CreateDirectory(this._settings.Path);

                DateTime dtCurrentDate = DateTime.Now;

                string sNewPathFolder = $@"{this._settings.Path}\LOG_{dtCurrentDate.Year}";

                if (!Directory.Exists(sNewPathFolder))
                    Directory.CreateDirectory(sNewPathFolder);

                string sFilename = $@"{sNewPathFolder}\LOG_{dtCurrentDate.Day.ToString("00")}-{dtCurrentDate.Month.ToString("00")}-{dtCurrentDate.Year}.log";
                File.AppendAllText(sFilename, sMessage, Encoding.UTF8);

                oResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogText-1]: {ex.Message}";
            }
            return oResponse;
        }

        public async Task<Response<string>> SetLogEmail(EnumLogCategory oLogCategory, string sName, string sMessage)
        {
            var oResponse = new Response<string>();
            try
            {
                var oEmail = new EmailDto.Request();
                oEmail.sSendTo = this._settings.EmailSendTo;
                oEmail.sReplyTo = this._settings.EmailReplyTo;
                oEmail.sSubject = string.Format(this._settings.EmailSubject, sName);
                oEmail.sMessage = sMessage.Replace("\r\n", "<br>");

                _ = this._emailApplication.SendEmail(oEmail);

                oResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogEmail-1]: {ex.Message}";
                _ = this.SetLogText(EnumLogCategory.ERROR, "SetLogEmail", ex);
            }
            return oResponse;
        }

        #endregion

        #region SECUNDARIOS (EXCEPTION)

        public async Task<Response<string>> SetLogText(EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData)
        {
            var oResponse = new Response<string>();
            try
            {
                oResponse = await this.SetLogText(oLogCategory, sName, this.GetExceptionMessageObject(oLogCategory, sName, oException, oData));
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogText-2]: {ex.Message}";
            }
            return oResponse;
        }

        public async Task<Response<string>> SetLogEmail(EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData)
        {
            var oResponse = new Response<string>();
            try
            {
                oResponse = await this.SetLogEmail(oLogCategory, sName, this.GetExceptionMessageObject(oLogCategory, sName, oException, oData));
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogEmail-2]: {ex.Message}";
            }
            return oResponse;
        }

        #endregion

        #region ADICIONALES (TEXT AND EMAIL)

        public async Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, string sMessage)
        {
            var oResponse = new Response<string>();
            try
            {
                if (oLogType == EnumLogType.TEXT || oLogType == EnumLogType.TEXT_N_EMAIL)
                    await this.SetLogText(oLogCategory, sName, sMessage);

                if (oLogType == EnumLogType.EMAIL || oLogType == EnumLogType.TEXT_N_EMAIL)
                    await this.SetLogEmail(oLogCategory, sName, sMessage);

                oResponse.IsSuccess = true;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogTextAndEmail-1]: {ex.Message}";
            }
            return oResponse;
        }

        public async Task<Response<string>> SetLog(EnumLogType oLogType, EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData)
        {
            var oResponse = new Response<string>();
            try
            {
                if (oLogType == EnumLogType.TEXT || oLogType == EnumLogType.TEXT_N_EMAIL)
                    await this.SetLogText(oLogCategory, sName, oException, oData);

                if (oLogType == EnumLogType.EMAIL || oLogType == EnumLogType.TEXT_N_EMAIL)
                    await this.SetLogEmail(oLogCategory, sName, oException, oData);

                oResponse.IsSuccess = true;
                return oResponse;
            }
            catch (Exception ex)
            {
                oResponse.Message = $"[SetLogTextAndEmail-2]: {ex.Message}";
            }
            return oResponse;
        }

        #endregion

        #region EXTRAS (FUNCIONES ESPECIALES)

        private string GetExceptionMessageObject(EnumLogCategory oLogCategory, string sName, Exception oException, params object[] oData)
        {
            if (oData == null)
                return this.GetExceptionMessage(oLogCategory, sName, oException);

            StringBuilder sb = new StringBuilder();
            int n = 0;
            foreach (object obj in oData)
            {
                sb.AppendLine();
                sb.AppendLine($"({++n}):");

                if (obj == null)
                {
                    sb.AppendLine("null");
                    continue;
                }

                try
                {
                    if (obj.GetType().IsClass)
                    {
                        sb.AppendLine(JsonConvert.SerializeObject(obj));
                    }
                    else
                    {
                        sb.AppendLine(obj.ToString());
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"Exception: {ex.Message}");
                }
            }
            return this.GetExceptionMessage(oLogCategory, sName, oException, sb.ToString());
        }

        private string GetExceptionMessage(EnumLogCategory oLogCategory, string sName, Exception oException, string sData = null)
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

            if (sData != null)
                sb.AppendLine($"[Data]: {sData}");

            return sb.ToString();
        }

        #endregion
    }
}
