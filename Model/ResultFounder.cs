using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class SiFounder
    {
        public string n { get; set; }
        public string t { get; set; }
    }

    public class Founder
    {
        public List<SiFounder> s { get; set; }
        public int f { get; set; }
        public List<List<object>> d { get; set; }
        public string _type { get; set; }
        public int n { get; set; }
    }
    public class ResultFounder
    {
        public string jsonrpc { get; set; }
        public Founder result { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }

}
