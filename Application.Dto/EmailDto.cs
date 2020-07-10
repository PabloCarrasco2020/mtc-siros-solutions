using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Dto
{
    public class EmailDto
    {
        public class Request
        {
            public string sSendTo { get; set; }
            public string sSubject { get; set; }
            public string sMessage { get; set; }
            public string sReplyTo { get; set; }
            public List<RequestAttachment> lstAttachments { get; set; }
        }

        public class RequestAttachment
        {
            public string sFileId { get; set; }
            public string sFileName { get; set; }
            public MemoryStream oFileData { get; set; }

        }

        public class Response
        {

        }
    }
}
