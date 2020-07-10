using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Helper;

namespace Application.Core
{
    public class EmailApplication : IEmailApplication
    {
        private readonly AppSettings.Email _settings;

        public EmailApplication(IOptions<AppSettings.Email> settings)
        {
            this._settings = settings.Value;
        }

        public async Task<Response<EmailDto.Response>> SendEmail(EmailDto.Request oItem)
        {
            try
            {
                var oResponse = new Response<EmailDto.Response>();
                oResponse.IsSuccess = false;

                if (string.IsNullOrEmpty(oItem.sSubject))
                {
                    oResponse.Message = "Se debe ingresar un Titulo.";
                    return oResponse;
                }

                if (string.IsNullOrEmpty(oItem.sSendTo))
                {
                    oResponse.Message = "Se debe ingresar un Remitente.";
                    return oResponse;
                }

                if (string.IsNullOrEmpty(oItem.sMessage))
                {
                    oResponse.Message = "Se debe ingresar un Mensaje.";
                    return oResponse;
                }

                MailAddress oSendFrom = new MailAddress("notificaciones_dgatr@mtc.gob.pe", this._settings.SenderDisplayName);
                MailAddress oSendTo = new MailAddress(oItem.sSendTo);
                MailMessage oMessage = new MailMessage(oSendFrom, oSendTo);
                oMessage.Subject = oItem.sSubject;
                oMessage.SubjectEncoding = Encoding.UTF8;
                oMessage.IsBodyHtml = true;
                oMessage.Body = oItem.sMessage;
                oMessage.BodyEncoding = Encoding.UTF8;

                if (!string.IsNullOrEmpty(oItem.sReplyTo))
                {
                    foreach (string sReplyTo in oItem.sReplyTo.Split(';'))
                    {
                        MailAddress oReplyTo = new MailAddress(sReplyTo);
                        oMessage.To.Add(oReplyTo);
                    }
                }

                if (oItem.lstAttachments != null)
                {
                    foreach (var item in oItem.lstAttachments)
                    {
                        Attachment oAttachment = new Attachment(item.oFileData, item.sFileName);
                        oAttachment.ContentId = item.sFileName;
                        oMessage.Attachments.Add(oAttachment);
                    }
                }

                using (SmtpClient oSmtpClient = new SmtpClient())
                {
                    NetworkCredential oNetworkCredential = new NetworkCredential();
                    oNetworkCredential.UserName = this._settings.SenderEmail;
                    oNetworkCredential.Password = this._settings.SenderPassword;

                    oSmtpClient.Host = this._settings.SmtpHost;
                    oSmtpClient.UseDefaultCredentials = false;
                    oSmtpClient.Credentials = oNetworkCredential;
                    oSmtpClient.EnableSsl = this._settings.SmtpEnableSSL.Equals("1");
                    oSmtpClient.Port = int.Parse(this._settings.SmtpPort);
                    await oSmtpClient.SendMailAsync(oMessage);
                }

                oResponse.IsSuccess = true;
                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
