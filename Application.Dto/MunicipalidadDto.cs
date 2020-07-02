using System;

namespace Application.Dto
{
    public class MunicipalidadDto
    {
        public class RSGet
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Direction { get; set; }
        }
        public class RQInsert
        {
            public string Name { get; set; }
            public string Direction { get; set; }
        }
        public class RQUpdate
        {
            public int Id { get; set; }
            public string Direction { get; set; }
        }
    }
}
