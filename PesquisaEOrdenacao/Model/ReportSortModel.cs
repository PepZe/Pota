using PesquisaEOrdenacao.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PesquisaEOrdenacao.Model
{
    public class ReportSortModel
    {
        public string Sort { get; set; }
        public long Time { get; set; }
        public int Length { get; set; }
        public OrdenationType ordenation { get; set; }
    }
}
