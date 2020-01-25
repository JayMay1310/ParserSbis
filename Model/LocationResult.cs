using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class S
    {
        public object n { get; set; }
        public object t { get; set; }
        public object s { get; set; }
    }

    public class Result
    {
        public List<S> s { get; set; }
        public List<List<object>> d { get; set; }
        public string _type { get; set; }
        public int n { get; set; }
    }

    public class LocationResult
    {
        public string jsonrpc { get; set; }
        public Result result { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }
}
