using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class Data
    {
        public string classid { get; set; }
        public int error_code { get; set; }
        public object addinfo { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public Data data { get; set; }
    }

    public class ErrorItem
    {
        public string jsonrpc { get; set; }
        public Error error { get; set; }
        public int id { get; set; }
    }
}
