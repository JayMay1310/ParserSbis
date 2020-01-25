using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class DataParsingItem
    {
        private string _id_sp;
        private string _companyName;//+
        private string _kindofactivity;//+
        private string _okevd;//+
        private string _allokevd;//+
        private string _amountWorker;//+
        private string _city;//+
        private string _adress;//+
        private string _index;//+
        private string _phone;//+
        private string _mail;//+
        private string _site;//+
        private string _revenue;//+
        private string _reliability;//+
        private string _inn;//+
        private string _kpp;//+
        private string _financial_analysis;//+
        private string _description;//+
        private string _dataRegistration;//+
        private string _bik;//+
        private string _ogrn;//+
        private string _okpo;//+
        private string _bank;//+
        private string _property;//Форма собственности//+
        private string _fax;//+
        private string _region;//+
        private string _genDirector;//+
        private string _founders;//+
        private string _certificate;//+

        public DataParsingItem(string id_sp, string companyName, string kindofactivity, string okevd, string all_okvd, string amountWorker, string city, string adress, string index, string phone, string mail,
            string site, string revenue, string reliability, string inn, string kpp, string financial_analysis, string description, string dataRegistration, string bik, string ogrn,
            string okpo, string bank, string property, string fax, string region, string genDirector, string founders, string certificate)
        {
            _id_sp = id_sp;
            _companyName = companyName;
            _kindofactivity = kindofactivity;
            _okevd = okevd;
            _allokevd = all_okvd;
            _amountWorker = amountWorker;
            _city = city;
            _adress = adress;
            _index = index;
            _phone = phone;
            _mail = mail;
            _site = site;
            _revenue = revenue;
            _reliability = reliability;
            _inn = inn;
            _kpp = kpp;
            _financial_analysis = financial_analysis;
            _description = description;
            _dataRegistration = dataRegistration;
            _bik = bik;
            _ogrn = ogrn;
            _okpo = okpo;
            _bank = bank;
            _property = property;
            _fax = fax;
            _region = region;
            _genDirector = genDirector;
            _founders = founders;
            _certificate = certificate;
        }

        public string IdSp
        {
            get { return _id_sp; }
            set
            {
                if (value.Equals(_id_sp)) return;
                _id_sp = value;
                RaisePropertyChanged("IdSp");
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (value.Equals(_companyName)) return;
                _companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string Kindofactivity
        {
            get { return _kindofactivity; }
            set
            {
                if (value.Equals(_kindofactivity)) return;
                _kindofactivity = value;
                RaisePropertyChanged("Kindofactivity");
            }
        }

        public string Okevd
        {
            get { return _okevd; }
            set
            {
                if (value.Equals(_okevd)) return;
                _okevd = value;
                RaisePropertyChanged("Okevd");
            }
        }

        public string AllOkevd
        {
            get { return _allokevd; }
            set
            {
                if (value.Equals(_allokevd)) return;
                _allokevd = value;
                RaisePropertyChanged("AllOkevd");
            }
        }

        public string AmountWorker
        {
            get { return _amountWorker; }
            set
            {
                if (value.Equals(_amountWorker)) return;
                _amountWorker = value;
                RaisePropertyChanged("AmountWorker");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (value.Equals(_city)) return;
                _city = value;
                RaisePropertyChanged("City");
            }
        }

        public string Adress
        {
            get { return _adress; }
            set
            {
                if (value.Equals(_adress)) return;
                _adress = value;
                RaisePropertyChanged("Adress");
            }
        }

        public string Index
        {
            get { return _index; }
            set
            {
                if (value.Equals(_index)) return;
                _index = value;
                RaisePropertyChanged("Index");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value.Equals(_phone)) return;
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Mail
        {
            get { return _mail; }
            set
            {
                if (value.Equals(_mail)) return;
                _mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        public string Site
        {
            get { return _site; }
            set
            {
                if (value.Equals(_site)) return;
                _site = value;
                RaisePropertyChanged("Site");
            }
        }

        public string Revenue
        {
            get { return _revenue; }
            set
            {
                if (value.Equals(_revenue)) return;
                _revenue = value;
                RaisePropertyChanged("Revenue");
            }
        }

        public string Reliability
        {
            get { return _reliability; }
            set
            {
                if (value.Equals(_reliability)) return;
                _reliability = value;
                RaisePropertyChanged("Reliability");
            }
        }

        public string Inn
        {
            get { return _inn; }
            set
            {
                if (value.Equals(_inn)) return;
                _inn = value;
                RaisePropertyChanged("Inn");
            }
        }

        public string Kpp
        {
            get { return _kpp; }
            set
            {
                if (value.Equals(_kpp)) return;
                _kpp = value;
                RaisePropertyChanged("Kpp");
            }
        }

        public string Financial_analysis
        {
            get { return _financial_analysis; }
            set
            {
                if (value.Equals(_financial_analysis)) return;
                _financial_analysis = value;
                RaisePropertyChanged("Financial_analysis");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Equals(_description)) return;
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string DataRegistration
        {
            get { return _dataRegistration; }
            set
            {
                if (value.Equals(_dataRegistration)) return;
                _dataRegistration = value;
                RaisePropertyChanged("DataRegistration");
            }
        }

        public string Bik
        {
            get { return _bik; }
            set
            {
                if (value.Equals(_bik)) return;
                _bik = value;
                RaisePropertyChanged("Bik");
            }
        }

        public string Ogrn
        {
            get { return _ogrn; }
            set
            {
                if (value.Equals(_ogrn)) return;
                _ogrn = value;
                RaisePropertyChanged("Ogrn");
            }
        }

        public string Okpo
        {
            get { return _okpo; }
            set
            {
                if (value.Equals(_okpo)) return;
                _okpo = value;
                RaisePropertyChanged("Okpo");
            }
        }

        public string Bank
        {
            get { return _bank; }
            set
            {
                if (value.Equals(_bank)) return;
                _bank = value;
                RaisePropertyChanged("Bank");
            }
        }

        public string Property
        {
            get { return _property; }
            set
            {
                if (value.Equals(_property)) return;
                _property = value;
                RaisePropertyChanged("Property");
            }
        }

        public string Fax
        {
            get { return _fax; }
            set
            {
                if (value.Equals(_fax)) return;
                _fax = value;
                RaisePropertyChanged("Fax");
            }
        }
        public string Region
        {
            get { return _region; }
            set
            {
                if (value.Equals(_region)) return;
                _region = value;
                RaisePropertyChanged("Region");
            }
        }

        public string Founders
        {
            get { return _founders; }
            set
            {
                if (value.Equals(_founders)) return;
                _founders = value;
                RaisePropertyChanged("Founders");
            }
        }
        
        public string GenDirector
        {
            get { return _genDirector; }
            set
            {
                if (value.Equals(_genDirector)) return;
                _genDirector = value;
                RaisePropertyChanged("GenDirector");
            }
        }

        public string Certificate
        {
            get { return _certificate; }
            set
            {
                if (value.Equals(_certificate)) return;
                _certificate = value;
                RaisePropertyChanged("Certificate");
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
