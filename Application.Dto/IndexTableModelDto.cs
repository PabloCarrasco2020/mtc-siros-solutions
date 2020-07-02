using System;
using System.Collections.Generic;

namespace Application.Dto
{
    public class IndexTableModelDto
    {
        public int? TotalPage { get; set; }
        public int? ActualPage { get; set; }
        public int? NroItems { get; set; }
        public List<TableModel> Items { get; set; }
    }
    public class TableModel
    {
        public int Id { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }
        public string Column9 { get; set; }
        public string Column10 { get; set; }
    }
}
