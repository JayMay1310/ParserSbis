using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Model
{
    public class TaskObject
    {
        private bool m_value;
        private string _id { get; set; }
        private string _selectedActivityName { get; set; } //+
        private string _selectedActivityCode1 { get; set; } //+
        private string _selectedActivityCode2 { get; set; } //+
        private string _selectedRegionCode1 { get; set; } //+
        private string _kodeCity { get; set; } //+
        private string _selectedRegionIdRegion { get; set; } //+
        private string _selectedTypeKontragent { get; set; } //+
        private string _selectedStatus { get; set; } //+
        private string _city { get; set; } //+
        private string _pagin { get; set; } //+
        private string _time { get; set; } //+
        private string _interval { get; set; } //+
        private string _completed { get; set; } //+
        private string _revenueMin { get; set; } //+
        private string _revenueMax { get; set; } //+
        private string _revenueCheck { get; set; } //+
        private string _regionName { get; set; } //+
        private string _check_okvd { get; set; }
        private string _idOKVD { get; set; }
        private string _kodOKVD { get; set; }
        private string _nameOKVD { get; set; }


        public TaskObject(string id,  string selectedActivityName, string selectedActivityCode1, string selectedActivityCode2, string selectedRegionCode1, string kodeCity, string selectedRegionIdRegion, 
            string selectedTypeKontragent, string selectedStatus, string city, string pagin, string time, string interval, string completed, string revenueMin, string revenueMax, string revenueCheck, string regionName,
            string check_okvd, string idOKVD, string kodOKVD, string nameOKVD)
        {
            _id = id;
            _selectedActivityName = selectedActivityName;
            _selectedActivityCode1 = selectedActivityCode1;
            _selectedActivityCode2 = selectedActivityCode2;
            _selectedRegionCode1 = selectedRegionCode1;
            _kodeCity = kodeCity;
            _selectedRegionIdRegion = selectedRegionIdRegion;
            _selectedTypeKontragent = selectedTypeKontragent;
            _selectedStatus = selectedStatus;
            _city = city;
            _pagin = pagin;
            _time = time;
            _interval = interval;
            _completed = completed;
            _revenueMin = revenueMin;
            _revenueMax = revenueMax;
            _revenueCheck = revenueCheck;
            _regionName = regionName;
            _check_okvd = check_okvd;
            _idOKVD = idOKVD;
            _kodOKVD = kodOKVD;
            _nameOKVD = nameOKVD;
        }

        public bool Value
        {
            get { return m_value; }
            set
            {
                if (m_value == value)
                    return;
                m_value = value;
                if (PropertyChanged != null)
                    OnPropertyChanged();
            }
        }
        public string Id
        {
            get { return _id; }
            set
            {
                if (value.Equals(_id)) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string SelectedActivityName
        {
            get { return _selectedActivityName; }
            set
            {
                if (value.Equals(_selectedActivityName)) return;
                _selectedActivityName = value;
                RaisePropertyChanged("SelectedActivityName");
            }
        }

        public string SelectedActivityCode1
        {
            get { return _selectedActivityCode1; }
            set
            {
                if (value.Equals(_selectedActivityCode1)) return;
                _selectedActivityCode1 = value;
                RaisePropertyChanged("SelectedActivityCode1");
            }
        }

        public string SelectedActivityCode2
        {
            get { return _selectedActivityCode2; }
            set
            {
                if (value.Equals(_selectedActivityCode2)) return;
                _selectedActivityCode2 = value;
                RaisePropertyChanged("SelectedActivityCode2");
            }
        }

        public string SelectedRegionCode1
        {
            get { return _selectedRegionCode1; }
            set
            {
                if (value.Equals(_selectedRegionCode1)) return;
                _selectedRegionCode1 = value;
                RaisePropertyChanged("SelectedRegionCode1");
            }
        }

        public string KodeCity
        {
            get { return _kodeCity; }
            set
            {
                if (value.Equals(_kodeCity)) return;
                _kodeCity = value;
                RaisePropertyChanged("KodeCity");
            }
        }

        public string SelectedRegionIdRegion
        {
            get { return _selectedRegionIdRegion; }
            set
            {
                if (value.Equals(_selectedRegionIdRegion)) return;
                _selectedRegionIdRegion = value;
                RaisePropertyChanged("SelectedRegionIdRegion");
            }
        }

        public string SelectedTypeKontragent
        {
            get { return _selectedTypeKontragent; }
            set
            {
                if (value.Equals(_selectedTypeKontragent)) return;
                _selectedTypeKontragent = value;
                RaisePropertyChanged("SelectedTypeKontragent");
            }
        }

        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (value.Equals(_selectedStatus)) return;
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public string Сitys
        {
            get { return _city; }
            set
            {
                if (value.Equals(_city)) return;
                _city = value;
                RaisePropertyChanged("Citys");
            }
        }

        public string Pagination
        {
            get { return _pagin; }
            set
            {
                if (value.Equals(_pagin)) return;
                _pagin = value;
                RaisePropertyChanged("Pagination");
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                if (value.Equals(_time)) return;
                _time = value;
                RaisePropertyChanged("Time");
            }
        }

        public string Intervals
        {
            get { return _interval; }
            set
            {
                if (value.Equals(_interval)) return;
                _interval = value;
                RaisePropertyChanged("Intervals");
            }
        }

        public string Completed
        {
            get { return _completed; }
            set
            {
                if (value.Equals(_completed)) return;
                _completed = value;
                RaisePropertyChanged("Completed");
            }
        }

        public string RevenueMin
        {
            get { return _revenueMin; }
            set
            {
                if (value.Equals(_revenueMin)) return;
                _revenueMin = value;
                RaisePropertyChanged("RevenueMin");
            }
        }

        public string RevenueMax
        {
            get { return _revenueMax; }
            set
            {
                if (value.Equals(_revenueMax)) return;
                _revenueMax = value;
                RaisePropertyChanged("RevenueMax");
            }
        }

        public string RevenueCheck
        {
            get { return _revenueCheck; }
            set
            {
                if (value.Equals(_revenueCheck)) return;
                _revenueCheck = value;
                RaisePropertyChanged("RevenueCheck");
            }
        }

        public string RegionName
        {
            get { return _regionName; }
            set
            {
                if (value.Equals(_regionName)) return;
                _regionName = value;
                RaisePropertyChanged("RegionName");
            }
        }

        public string Check_okvd
        {
            get { return _check_okvd; }
            set
            {
                if (value == _check_okvd) return;
                _check_okvd = value;
                RaisePropertyChanged("Check_okvd");
            }
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
