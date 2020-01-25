using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    [DataContract]
    public class RegionItem
    {
        private bool m_value;
        private string _name;
        private string _idRegion;
        private string _code1;
        private string _code2;
        private string _code3;
        private string _code4;
        private string _code5;
        private string _visibleName;

        public RegionItem(bool value, string idRegion, string name, string code1, string code2, string code3, string code4, string code5)
        {
            m_value = value;
            _visibleName = String.Format("{0} {1}", code1, name);
            _idRegion = idRegion;
            _name = name;
            _code1 = code1;
            _code2 = code2;
            _code3 = code3;
            _code4 = code4;
            _code5 = code5;
        }

        [DataMember]
        public bool Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                RaisePropertyChanged("Value");
            }
        }

        public string VisibleName
        {
            get { return _visibleName; }
            set
            {
                if (value == _visibleName) return;
                _visibleName = value;
                RaisePropertyChanged("VisibleName");
            }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        [DataMember]
        public string IdRegion
        {
            get { return _idRegion; }
            set
            {
                if (value == _idRegion) return;
                _idRegion = value;
            }
        }
        [DataMember]
        public string Code1
        {
            get { return _code1; }
            set
            {
                if (value == _code1) return;
                _code1 = value;
            }
        }
        [DataMember]
        public string Code2
        {
            get { return _code2; }
            set
            {
                if (value == _code2) return;
                _code2 = value;
            }
        }

        [DataMember]
        public string Code3
        {
            get { return _code3; }
            set
            {
                if (value == _code3) return;
                _code3 = value;
            }
        }

        [DataMember]
        public string Code4
        {
            get { return _code4; }
            set
            {
                if (value == _code4) return;
                _code4 = value;
            }
        }
        [DataMember]
        public string Code5
        {
            get { return _code5; }
            set
            {
                if (value == _code5) return;
                _code5 = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
