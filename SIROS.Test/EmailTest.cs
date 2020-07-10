using System;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transversal.Common;

namespace SIROS.Test
{
    [TestClass]
    public class EmailTest
    {
        private string SenderEmail = "Tramite_en_Linea@mtc.gob.pe";
        private string SenderPassword = "Tram1t3";
        private string SenderDisplay = "test";
        private string SmtpHot = "correo.mtc.gob.pe";
        private int SmtpPort = 25;

        [TestMethod]
        public async Task TestEmail()
        {
            var oEmail = new EmailDto.Request();
            oEmail.sSendTo = "acisneros@mtc.gob.pe";
            oEmail.sReplyTo = null;
            oEmail.sSubject = "prueba subject";
            oEmail.sMessage = "hola mundo";
            await this.SendEmail(oEmail);

            Assert.IsTrue(true);
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

                var oSendFrom = new System.Net.Mail.MailAddress(SenderEmail, SenderDisplay);
                var oSendTo = new System.Net.Mail.MailAddress(oItem.sSendTo);
                var oMessage = new System.Net.Mail.MailMessage(oSendFrom, oSendTo);
                oMessage.Subject = oItem.sSubject;
                oMessage.SubjectEncoding = Encoding.UTF8;
                oMessage.IsBodyHtml = true;
                oMessage.Body = oItem.sMessage;
                oMessage.BodyEncoding = Encoding.UTF8;

                if (!string.IsNullOrEmpty(oItem.sReplyTo))
                {
                    foreach (string sReplyTo in oItem.sReplyTo.Split(';'))
                    {
                        var oReplyTo = new System.Net.Mail.MailAddress(sReplyTo);
                        oMessage.To.Add(oReplyTo);
                    }
                }

                if (oItem.lstAttachments != null)
                {
                    foreach (var item in oItem.lstAttachments)
                    {
                        var oAttachment = new System.Net.Mail.Attachment(item.oFileData, item.sFileName);
                        oAttachment.ContentId = item.sFileName;
                        oMessage.Attachments.Add(oAttachment);
                    }
                }

                using (var oSmtpClient = new System.Net.Mail.SmtpClient())
                {
                    var oNetworkCredential = new System.Net.NetworkCredential();
                    oNetworkCredential.UserName = SenderEmail;
                    oNetworkCredential.Password = SenderPassword;

                    oSmtpClient.Host = SmtpHot;
                    oSmtpClient.UseDefaultCredentials = false;
                    oSmtpClient.Credentials = oNetworkCredential;
                    oSmtpClient.EnableSsl = true;
                    oSmtpClient.Port = SmtpPort;
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