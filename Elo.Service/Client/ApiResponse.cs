using System;
using System.Collections.Generic;
using System.Text;

namespace Elo.Service.Client
{
    internal class ApiResponse
    {
        public bool Success { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public Error Error { get; set; }
        public Quotes Quotes { get; set; }
    }
}

internal class Error
{
    public int Code { get; set; }
    public string Info { get; set; }
}