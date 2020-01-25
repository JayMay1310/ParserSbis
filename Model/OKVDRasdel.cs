using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{

    public class Sc
    {
        public string n { get; set; }
        public string t { get; set; }
        public string s { get; set; }
    }

    public class OKVDRasdel
    {
        public List<Sc> s { get; set; }
        public int f { get; set; }
        public List<List<object>> d { get; set; }
        public string _type { get; set; }
        public bool e { get; set; }
    }

    public class RootOKVDRasdel
    {
        public string jsonrpc { get; set; }
        public OKVDRasdel result { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }

}
