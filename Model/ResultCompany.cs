using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class Si
    {
        public string n { get; set; }
        public string t { get; set; }
        public string s { get; set; }
    }

    public class ResultS
    {
        public List<Si> s { get; set; }
        public List<List<object>> d { get; set; }
        public string _type { get; set; }
        public bool n { get; set; }
    }

    public class ResultCompany
    {
        public string jsonrpc { get; set; }
        public ResultS result { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }
}
