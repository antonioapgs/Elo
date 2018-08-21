using System;
using System.Collections.Generic;
using System.Text;

namespace Elo.Service.Client
{
    public class Quotes
    {
        public DateTime Date { get; set; }
        public decimal USDEUR { get; set; }
        public decimal USDBRL { get; set; }
        public decimal USDARS { get; set; }
    }
}