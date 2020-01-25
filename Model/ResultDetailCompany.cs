using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class SDetail
    {
        public string n { get; set; }
        public object t { get; set; }
    }

    public class ResultDetail
    {
        public List<SDetail> s { get; set; }
        public List<object> d { get; set; }
        public string _type { get; set; }
    }

    public class ResultDetailCompany
    {
        public string jsonrpc { get; set; }
        public ResultDetail result { get; set; }
        public ResultCertificate certificate { get; set; }
        public ResultFounder founder { get; set; }
        public int id { get; set; }
        public int protocol { get; set; }
    }
}
