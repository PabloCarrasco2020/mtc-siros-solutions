using System;
namespace Application.Dto
{
    public class ComboModelDto
    {
        public class XCodigo
        {
            public string sCodigo { get; set; }
            public string sDescription { get; set; }
        }
        public class XId
        {
            public int? nId { get; set; }
            public string sDescription { get; set; }
        }
    }
}
