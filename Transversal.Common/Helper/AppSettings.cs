namespace Transversal.Common.Helper
{
    public class AppSettings
    {
        public class ConnectionStrings
        {
            public string SchemaDB { get; set; }
            public string SIROSConnection { get; set; }
        }

        public class Servicios
        {
            public string ReniecAPI { get; set; }
            public string MiddleWareAPI { get; set; }
        }

        public class CredencialesSSO
        {
            public string ApplicationId { get; set; }
            public string TokenUser { get; set; }
            public string TokenPassword { get; set; }
            public string Profiles { get; set; }
        }

        public class CredencialesMiddleWare
        {
            public string TokenUser { get; set; }
            public string TokenPassword { get; set; }
        }

        public class JWT
        {
            public string SecretKey { get; set; }
            public string MinutesExpiration { get; set; }
        }

        public class Email
        {
            public string SenderEmail { get; set; }
            public string SenderPassword { get; set; }
            public string SenderDisplayName { get; set; }
            public string SmtpHost { get; set; }
            public string SmtpPort { get; set; }
            public string SmtpEnableSSL { get; set; }
        }

        public class Logs
        {
            public string EmailSubject { get; set; }
            public string EmailSendTo { get; set; }
            public string EmailReplyTo { get; set; }
            public string Path { get; set; }
        }
    }
}
