using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class OKVDItem
    {
        private string _idOKVD;
        private string _kodOKVD;
        private string _nameOKVD;
        private string _fullcodeOKVD;
        public string _nameOKVD_KodOKVD;

        public OKVDItem(string idOKVD, string kodOKVD, string nameOKVD, string fullcodeOKVD)
        {
            _idOKVD = idOKVD;
            _kodOKVD = kodOKVD;
            _nameOKVD = nameOKVD;
            _fullcodeOKVD = fullcodeOKVD;
            _nameOKVD_KodOKVD = String.Format("{0} {1}", nameOKVD, kodOKVD);
        }

        public string IdOKVD
        {
            get { return _idOKVD; }
            set
            {
                if (value == _idOKVD) return;
                _idOKVD = value;
                RaisePropertyChanged("IdOKVD");
            }
        }

        public string KodOKVD
        {
            get { return _kodOKVD; }
            set
            {
                if (value == _kodOKVD) return;
                _kodOKVD = value;
                RaisePropertyChanged("KodOKVD");
            }
        }
        public string NameOKVD
        {
            get { return _nameOKVD; }
            set
            {
                if (value == _nameOKVD) return;
                _nameOKVD = value;
                RaisePropertyChanged("NameOKVD");
            }
        }

        public string FullcodeOKVD
        {
            get { return _fullcodeOKVD; }
            set
            {
                if (value == _fullcodeOKVD) return;
                _fullcodeOKVD = value;
                RaisePropertyChanged("FullcodeOKVD");
            }
        }

        public string NameOKVD_KodOKVD
        {
            get { return _nameOKVD_KodOKVD; }
            set
            {
                if (value == _nameOKVD_KodOKVD) return;
                _nameOKVD_KodOKVD = value;
                RaisePropertyChanged("NameOKVD_KodOKVD");
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
