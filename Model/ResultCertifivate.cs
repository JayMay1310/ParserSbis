using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{

    public class SiCertificate
    {
        public object n { get; set; }
        public object t { get; set; }
        public object s { get; set; }
    }
    public class Certificate
    {
        public List<S> s { get; set; }
        public int f { get; set; }
        public List<List<object>> d { get; set; }
        public string _type { get; set; }
    }

    public class ResultCertificate
    {
        public string jsonrpc { get; set; }
        public Certificate result { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }
}
