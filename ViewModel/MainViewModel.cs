
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using ParserSbis.Model;
using ParserSbis.Services;
using System.Windows.Input;
using ParserSbis.Utils;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Data;
using System;
using Microsoft.Win32;
using System.IO;
using KBCsv;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Documents;
using System.Xml.Linq;
using ParserSbis.Models;
using ParserSbis.ViewModel.Base;
using System.Windows.Controls.Primitives;
using System.Runtime.Serialization;

namespace ParserSbis.ViewModel
{

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public MainWindowModel Model
        {
            get; set;
        }

        private readonly IDataService _dataService;

        api_sbis sbis;

        public List<string> TypeKontragent { get; set; }
        public List<string> viewStatus { get; set; }
        public XmlExecute xmlExecute;

        public ObservableCollection<RegionItem> viewRegion { get; set; }
        public ObservableCollection<RegionItem> viewCity { get; set; }
        public static ObservableCollection<ActivityItem> viewActivity { get; set; }
        public ObservableCollection<DataParsingItem> viewCompanyRaw { get; set; }
        public ObservableCollection<OKVDItem> viewOKVED { get; set; }

        public static CollectionViewSource viewCompany = new CollectionViewSource();


        public ICommand Auth { get; private set; }
        public ICommand GetData { get; private set; }
        public ICommand RefreshCatalog { get; private set; }
        public ICommand ClearListView { get; private set; }
        public ICommand OpenTaskDialog { get; private set; }
        public ICommand StopTask { get; private set; }
        public ICommand ContiniueParser { get; private set; }
        public ICommand LoadIdSp { get; private set; }
        public ICommand SaveXmlToCsv { get; private set; }
        public ICommand StartSearchCommand { get; private set; }
        public ICommand AddActivivityCommand { get; private set; }
        public ICommand AddRegionCommand { get; private set; }


        public RelayCommand NavigateSearchCommand { get; set; }
        public RelayCommand NavigateFilterCommand { get; set; }
        public RelayCommand NavigateSettingsCommand { get; set; }
        public RelayCommand NavigateLogCommand { get; set; }
        public RelayCommand NavigateHomeCommand { get; set; }


        public ObservableCollection<TaskObject> TaskList { get; set; }

        private string fileCashePath = @"Data/cache.xml";
        /// <summary>
        /// 
        /// </summary>
        private bool _diapozonRevenueFilter;
        public bool DiapozonRevenueFilter
        {
            get { return _diapozonRevenueFilter; }
            set
            {
                _diapozonRevenueFilter = value;
                RaisePropertyChanged("DiapozonRevenueFilter");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _selectedActivityCheckBox;
        public bool SelectedActivityCheckBox
        {
            get
            {
                return _selectedActivityCheckBox;
            }

            set
            {
                if (value != false)
                {
                    SelectedOKVEDCheckBox = false;
                }

                _selectedActivityCheckBox = value;
                this.RaisePropertyChanged("SelectedActivityCheckBox");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _selectedOKVEDCheckBox;
        public bool SelectedOKVEDCheckBox
        {
            get { return _selectedOKVEDCheckBox; }
            set
            {
                if (value != false)
                {
                    SelectedActivityCheckBox = false;
                }
                _selectedOKVEDCheckBox = value;
                RaisePropertyChanged("SelectedOKVEDCheckBox");
            }
        }
    
        private bool _isCheckedSeveralRegion;
        public bool IsCheckedSeveralRegion
        {
            get { return _isCheckedSeveralRegion; }
            set
            {
                _isCheckedSeveralRegion = value;
                RaisePropertyChanged("IsCheckedSeveralRegion");
            }
        }


        /// <summary>
        /// Проверяет запущена ли задача
        /// </summary>
        private bool _checkTaskStart;
        public bool CheckTaskStart
        {
            get { return _checkTaskStart; }
            set
            {
                if (_checkTaskStart != value)
                {
                    _checkTaskStart = value;
                    RaisePropertyChanged("CheckTaskStart");
                }
            }
        }

        /// <summary>
        /// Проверяет нужно ли получать соучередителей.
        /// </summary>
        private bool _isOverrideChecked;
        public bool IsOverrideChecked
        {
            get { return _isOverrideChecked; }
            set
            {
                if (_isOverrideChecked != value)
                {
                    _isOverrideChecked = value;
                    RaisePropertyChanged("IsOverrideChecked");
                }
            }
        }

        /// <summary>
        /// Проверяет нужно ли получать сертификаты.
        /// </summary>
        private bool _isCertificateChecked;
        public bool IsCertificateChecked
        {
            get { return _isCertificateChecked; }
            set
            {
                if (_isCertificateChecked != value)
                {
                    _isCertificateChecked = value;
                    RaisePropertyChanged("IsCertificateChecked");
                }
            }
        }

        /// <summary>
        /// Выручка min
        /// </summary>
        private long _revenueMin;
        public long RevenueMin
        {
            get { return _revenueMin; }
            set
            {
                _revenueMin = value;
                RaisePropertyChanged("RevenueMin");
            }
        }

        /// <summary>
        /// Выручка max
        /// </summary>
        private long _revenueMax;
        public long RevenueMax
        {
            get { return _revenueMax; }
            set
            {
                _revenueMax = value;
                RaisePropertyChanged("RevenueMax");
            }
        }
        /// <summary>
        /// Свойство "Общее количество полученных данных"
        /// </summary>
        private string _countItem;
        public string CountItem
        {
            get { return _countItem; }
            set
            {
                _countItem = value;
                RaisePropertyChanged("CountItem");
            }
        }

        /// <summary>
        /// Поле для вывода справочной информаций.
        /// </summary>
        private string _helpText;
        public string HelpText
        {
            get { return _helpText; }
            set
            {
                _helpText = value;
                RaisePropertyChanged("HelpText");
            }
        }

        
        /// <summary>
        /// Путь до файла справки. 
        /// </summary>
        private string _helpFilePath;
        public string HelpFilePath
        {
            get { return _helpFilePath; }
            set
            {
                _helpFilePath = value;
                RaisePropertyChanged("HelpFilePath");
            }
        }

        /// <summary>
        /// Свойство "Интервал межу запросами API"
        /// </summary>
        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                RaisePropertyChanged("Interval");
            }
        }
        /// <summary>
        /// Свойство progressBar во времени выполнения.
        /// </summary>
        private int _valueProgressBar;
        public int ValueProgressBar
        {
            get { return _valueProgressBar; }
            set
            {
                _valueProgressBar = value;
                RaisePropertyChanged("ValueProgressBar");
            }
        }

        /// <summary>
        /// Search
        /// </summary>
        private string _search;
        public string Search
        {
            get { return this._search; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this._search, value))
                {
                    this._search = value;
                    RaisePropertyChanged("Search"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }


        /// <summary>
        /// Login
        /// </summary>
        private string _login;
        public string Login
        {
            get { return this._login; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this._login, value))
                {
                    this._login = value;
                    RaisePropertyChanged("Login"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        /// <summary>
        /// Password
        /// </summary>
        private string _password;
        public string Password
        {
            get { return this._password; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this._password, value))
                {
                    this._password = value;
                    RaisePropertyChanged("Password"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        /// <summary>
        /// Индиктор прогресса
        /// </summary>
        private bool _progressVisible;
        public bool ProgressVisible
        {
            get { return this._progressVisible; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this._progressVisible, value))
                {
                    this._progressVisible = value;
                    RaisePropertyChanged("ProgressVisible"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string _OutPutText;
        public string OutPutText
        {
            get { return _OutPutText; }
            set { if (_OutPutText == value) return; _OutPutText = value; RaisePropertyChanged(nameof(OutPutText)); }
        }

        private RegionItem _selectedRegion;
        public RegionItem SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                if (value != null)
                {
                    fillSeelctModel(value);
                    //SelectedModel = value.
                }
                _selectedRegion = value;
            }
        }

        private RegionItem _selectedCity;
        public RegionItem SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (value != null)
                {
                    _selectedCity = value;
                }

            }
        }
        /// <summary>
        /// Вид деятельности
        /// </summary>
        private ActivityItem _selectedActivity;
        public ActivityItem SelectedActivity
        {
            get { return _selectedActivity; }
            set
            {
                if (value != null)
                {
                    _selectedActivity = value;
                    RaisePropertyChanged("SelectedActivity");
                }
            }
        }

        /// <summary>
        /// ОКВД Select
        /// </summary>
        private OKVDItem _selectedOKVED;
        public OKVDItem SelectedOKVED
        {
            get { return _selectedOKVED; }
            set
            {
                if (value != null)
                {
                    _selectedOKVED = value;
                }
            }
        }

        /// <summary>
        /// Свойство поля контрагента
        /// </summary>
        private string _selectedTypeKontragent;
        public string SelectedTypeKontragent
        {
            get { return _selectedTypeKontragent; }
            set
            {
                if (value != null)
                {
                    _selectedTypeKontragent = value;
                }
            }
        }
        /// <summary>
        /// Статус 
        /// </summary>
        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (value != null)
                {
                    _selectedStatus = value;
                }
            }
        }

        /// <summary>
        /// key_api
        /// </summary>
        private string _key_api;
        public string Key_api
        {
            get { return _key_api; }
            set
            {
                if (value != null)
                {
                    _key_api = value;
                    RaisePropertyChanged("Key_api");
                }
            }
        }

        /// <summary>
        /// Пагинация  
        /// </summary>
        private int _pagination;
        public int Pagination
        {
            get { return _pagination; }
            set
            {
                _pagination = value;
                RaisePropertyChanged("Pagination");

            }
        }

        /// <summary>
        /// Данных в Фильтре
        /// </summary>
        private int _сountFilter;
        public int CountFilter
        {
            get { return _сountFilter; }
            set
            {
                _сountFilter = value;
                RaisePropertyChanged("CountFilter");

            }
        }

        /// <summary>
        /// Count Данных о контрагентах
        /// </summary>
        private int _сountContragent;
        public int CountContragent
        {
            get { return _сountContragent; }
            set
            {
                _сountContragent = value;
                RaisePropertyChanged("CountContragent");

            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(FacadeViewModel FacadeViewModel)
             : base(FacadeViewModel)
        {
            DispatcherHelper.Initialize();

            FacadeViewModel.MainViewModel = this;

            IDataService dataService = new DataService();
            _dataService = dataService;
            _dataService.GetDataRegion(
                (model, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                    viewRegion = new ObservableCollection<RegionItem>(model.Select(b => new RegionItem(b.Value, b.IdRegion, b.Name, b.Code1, b.Code2, b.Code3, b.Code4, b.Code5)));
                });

            _dataService.GetDataActivity(
                (model_activity, error) =>
                {
                if (error != null)
                {
                    // Report error here
                    return;
                }

viewActivity = new ObservableCollection<ActivityItem>(model_activity.Select(b => new ActivityItem(b.Value, b.IdRegion, b.Name, b.Code1, b.Code2, b.Code3, b.Code4, b.Code5)));
});

            _dataService.GetDataOKVD(
                (action, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                    viewOKVED = new ObservableCollection<OKVDItem>(action.Select(b => new OKVDItem(b.IdOKVD, b.KodOKVD, b.NameOKVD, b.FullcodeOKVD)));
                });

            TypeKontragent = new List<string>();
            TypeKontragent.Add("Все контрагенты");
            TypeKontragent.Add("ЮрЛицо");
            TypeKontragent.Add("Предприниматель");
            TypeKontragent.Add("Банк");
            TypeKontragent.Add("НалоговаяИнспекция");
            TypeKontragent.Add("ПенсионныйФонд");
            TypeKontragent.Add("ФСС");
            TypeKontragent.Add("ТОГС");//Рстат
                                       //TypeKontragent.Add("Ненадежные поставщики");//Ненадежные поставщики

            //Selectbox Status

            viewStatus = new List<string>();
            viewStatus.Add("В любом статусе");
            viewStatus.Add("Только действующие");
            viewStatus.Add("Только ликвидированные");

            viewCity = new ObservableCollection<RegionItem>();
            viewCompanyRaw = new ObservableCollection<DataParsingItem>();
            viewCompanyRaw.Add(new DataParsingItem("-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-"));
            viewCompany.Source = viewCompanyRaw;
            CountItem = "0";

            Key_api = Properties.Settings.Default.session_id;

            Pagination = 50;
            Interval = 1;
            SelectedOKVEDCheckBox = false;
            SelectedActivityCheckBox = true;
            CheckTaskStart = true;
            ValueProgressBar = 0;

            DiapozonRevenueFilter = false;

            IsCheckedSeveralRegion = true;

            ProgressVisible = false;
            sbis = new api_sbis();

            //CountFilter = CountFilterMethod();
            //CountContragent = CountContragentMEthod();
            FillCountFooter();


            //sbis.GetOKVD(Properties.Settings.Default.session_id, 6034301);
            Login = Properties.Settings.Default.Login;
            Password = Properties.Settings.Default.Password;

            Auth = new RelayCommand(() => AuthExecute(Login, Password), () => true);
            RefreshCatalog = new RelayCommand(() => RefreshCatalogExecute(), () => true);
            StopTask = new RelayCommand(() => StopTaskExecute(), () => true);
            ContiniueParser = new RelayCommand(() => ContiniueParserExecute(), () => true);
            LoadIdSp = new RelayCommand(() => LoadIdSpExecute(), () => true);
            SaveXmlToCsv = new RelayCommand(() => SaveXmlToCsvExecute(), () => true);
            StartSearchCommand = new RelayCommand(() => StartSearchCommandExecute(), () => true);
            AddActivivityCommand = new RelayCommand(AddActivivityDialogExecute);
            AddRegionCommand = new RelayCommand(AddRegionDialogExecute);


            NavigateSearchCommand = new RelayCommand(NavigateSearch);
            NavigateFilterCommand = new RelayCommand(NavigateFilter);
            NavigateSettingsCommand = new RelayCommand(NavigateSettings);
            NavigateLogCommand = new RelayCommand(NavigateLog);
            NavigateHomeCommand = new RelayCommand(NavigateHome);

            SimpleIoc.Default.Register<IMsgService, MsgService>();
            SimpleIoc.Default.Register<eventsLog>();

            var s = SimpleIoc.Default.GetInstance<IMsgService>();
            s.PublishEvent += (sender, args) =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    //OutPutText += $"\n{args.Msg}";
                    OutPutText = $"{args.Msg}\n" + OutPutText;
                });
            };

            xmlExecute = new XmlExecute();

            Model = MainWindowModel.GetModel();

            string helpPath = @"Help/help.txt";
            if (File.Exists(helpPath))
            {
                using (StreamReader sr = new StreamReader(helpPath))
                {
                    HelpText = sr.ReadToEnd();
                }
            }

            else
            {
                HelpText = "";
            }

            UniversalLog("Программа работает и готова к использованию");
        }

        private void AuthExecute(string login, string password)
        {
            Task.Factory.StartNew(() =>
            {
                ProgressVisible = true;
                Properties.Settings.Default.Login = login;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
                string id_session = null;
                try
                {
                    id_session = sbis.Auth(login, password);
                }
                catch
                {
                    MessageBox.Show("Ошибка авторизаций");
                }

                if (id_session != null)
                {
                    Properties.Settings.Default.session_id = id_session;
                    Properties.Settings.Default.Save();
                    Key_api = id_session;
                }
                else
                {
                    Properties.Settings.Default.session_id = "0";
                    Properties.Settings.Default.Save();
                }
                ProgressVisible = false;
            });
        }

        private void RefreshCatalogExecute()
        {
            Task.Factory.StartNew(() =>
            {
                ProgressVisible = true;
                List<RootOKVDRasdel> listOKVDWrite = new List<RootOKVDRasdel>();

                sbis.RefreshCatalog(Properties.Settings.Default.session_id);
                sbis.RefreshActivity(Properties.Settings.Default.session_id);
                //Получаем разделы ОКВД 
                RootOKVDRasdel listRasdel = sbis.GetOKVDRasdel(Properties.Settings.Default.session_id);
                //Получаем ОКВД

                XmlDocument _doc = new XmlDocument();

                foreach (var itemOKVD in listRasdel.result.d)
                {
                    RootOKVDRasdel listOKVD = sbis.GetOKVD(Properties.Settings.Default.session_id, Convert.ToInt32(itemOKVD[0]));

                    foreach (var itemOKVDFin in listOKVD.result.d)
                    {
                        RootOKVDRasdel listOKVDFin = sbis.GetOKVD(Properties.Settings.Default.session_id, Convert.ToInt32(itemOKVDFin[0]));

                        foreach (var itemOKVDWrite in listOKVDFin.result.d)
                        {
                            _doc.Load(@"Data/list_okvd.xml");

                            XmlElement okvd = _doc.CreateElement("TableOKVD");

                            XmlElement idOKVD = _doc.CreateElement("idOKVD");
                            idOKVD.InnerText = itemOKVDWrite[0].ToString();
                            okvd.AppendChild(idOKVD);

                            XmlElement kodOKVD = _doc.CreateElement("kodOKVD");
                            kodOKVD.InnerText = itemOKVDWrite[1].ToString();
                            okvd.AppendChild(kodOKVD);

                            XmlElement nameOKVD = _doc.CreateElement("nameOKVD");
                            nameOKVD.InnerText = itemOKVDWrite[2].ToString();
                            okvd.AppendChild(nameOKVD);

                            XmlElement fullcodeOKVD = _doc.CreateElement("fullcodeOKVD");
                            fullcodeOKVD.InnerText = itemOKVDWrite[3].ToString();
                            okvd.AppendChild(fullcodeOKVD);


                            _doc.DocumentElement.AppendChild(okvd);
                            _doc.Save(@"Data/list_okvd.xml");
                        }

                        Thread.Sleep(1000);
                    }
                }


                ProgressVisible = false;

                MessageBox.Show("Справочники обновлены");
            });
        }

        /// <summary>
        /// Метод заполняет список городами. 
        /// </summary>
        /// <param name="_selectedMarka"></param>
        private void fillSeelctModel(RegionItem _selectedCity)
        {
            Task.Factory.StartNew(() =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    // Some logic here
                    if (_selectedCity != null)
                    {
                        if (viewCity != null)
                        {
                            viewCity.Clear();
                        }

                        _dataService.GetDataCity(
                            (posts, error) =>
                            {
                                if (error != null)
                                {
                                    // Report error here
                                    return;
                                }

                                ObservableCollection<RegionItem> viewCityBuffer = new ObservableCollection<RegionItem>(posts.Where(b => b.Code2 == _selectedCity.Code2).Select(c => new RegionItem(c.Value, c.IdRegion, c.Name, c.Code1, c.Code2, c.Code3, c.Code4, c.Code5)));

                                if (viewCity != null)
                                {
                                    foreach (RegionItem item in viewCityBuffer)
                                    {
                                        if (item.Name == "Вся Россия")
                                        {
                                            continue;
                                        }

                                        viewCity.Add(new RegionItem(item.Value, item.IdRegion, item.Name, item.Code1, item.Code2, item.Code3, item.Code4, item.Code5));
                                    }
                                }
                            });

                        //foreach (RegionItem item in _selectedCity.Name)
                        //{
                        //    viewCity.Add(new ModelItem(item.id, item.make_id, item.name, item.domestic, item.sport, item.parent_id, item.power, item.weight, item.price));
                        //}
                    }
                });
            });
        }

        private bool WriteXmlIdSp(string id_sp, string region_name)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(@"Data/id_sp.xml");
            XmlNode root = _doc.DocumentElement;

            XmlNode find_idsp = root.SelectSingleNode(String.Format("IdSpTable[id='{0}']", id_sp));

            if (find_idsp == null)
            {
                XmlElement newIdSptable = _doc.CreateElement("IdSpTable");

                XmlElement id_spNode = _doc.CreateElement("id");
                id_spNode.InnerText = id_sp;
                newIdSptable.AppendChild(id_spNode);

                XmlElement regionNode = _doc.CreateElement("region_name");
                regionNode.InnerText = region_name;
                newIdSptable.AppendChild(regionNode);

                _doc.DocumentElement.AppendChild(newIdSptable);
                _doc.Save(@"Data/id_sp.xml");

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод останавливает выполнение задачи путем присвоения свойству CheckTaskStart True
        /// </summary>
        private void StopTaskExecute()
        {
            CheckTaskStart = true;
            UniversalLog("Остановка задачи.");
        }

        private void LoadIdSpExecute()
        {
            MessageBoxResult result = MessageBox.Show("Очистить историю?", "", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    XDocument xdoc = new XDocument(new XElement("Table"));
                    xdoc.Save(@"Data/id_sp.xml");
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }

            //Если несколько регионов, то используем новый метод, иначе старый. 
            if (IsCheckedSeveralRegion)
            {
                Task.Factory.StartNew(() =>
                {
                    CheckTaskStart = false;
                    ProgressVisible = true;

                    //Читаем список выбранных регионов.
                    NetDataContractSerializer serializer = new NetDataContractSerializer();

                    List<RegionItem> clonedRegion = null;
                    using (FileStream fs = File.OpenRead("region.xml"))
                    {
                        clonedRegion = (List<RegionItem>)serializer.Deserialize(fs);
                    }

                    List<ActivityItem> clonedActivity = null;
                    using (FileStream fs = File.OpenRead("activity.xml"))
                    {
                        clonedActivity = (List<ActivityItem>)serializer.Deserialize(fs);
                    }
                    List<RegionItem> viewCityBuffer = new List<RegionItem>();
                    foreach (RegionItem itemRegion in clonedRegion)
                    {
                        if (CheckTaskStart == true)
                        {
                            break;
                        }

                        if (itemRegion.Value == true)
                        {
                            _dataService.GetDataCity(
                                (posts, error) =>
                                {
                                    if (error != null)
                                    {
                                        // Report error here
                                        return;
                                    }
                                    
                                    viewCityBuffer = new List<RegionItem>(posts.Where(b => b.Code2 == itemRegion.Code2).Select(c => new RegionItem(c.Value, c.IdRegion, c.Name, c.Code1, c.Code2, c.Code3, c.Code4, c.Code5)));
                                });

                            foreach (RegionItem itemCity in viewCityBuffer)
                            {
                                if (CheckTaskStart == true)
                                {
                                    break;
                                }
                                foreach (ActivityItem itemActivity in clonedActivity)
                                {

                                    string key = Properties.Settings.Default.session_id;
                                    Key_api = key;
                                    ResultCompany company = new ResultCompany();
                                    List<ResultCompany> listCompany = new List<ResultCompany>();

                                    List<ResultDetailCompany> detailCompanyList = new List<ResultDetailCompany>();
                                    string city;
                                    string kodeCity;
                                    if (itemCity != null)
                                    {
                                        city = itemCity.Name;
                                        city = Regex.Replace(city, "г.", "");
                                        city = city.Trim();

                                        kodeCity = itemCity.Code1;
                                    }
                                    else
                                    {
                                        city = null;
                                        kodeCity = null;
                                    }

                                    int pagin = 0;
                                    string regionName = String.Empty;
                                    string vid_deatelnosti = String.Empty;
                                    if (itemRegion != null)
                                    {
                                        regionName = itemRegion.Name;
                                    }
                                    if (itemActivity != null)
                                    {
                                        vid_deatelnosti = itemActivity.Name;
                                    }

                                    if (itemActivity == null)
                                    {
                                        MessageBox.Show("Не выбран вид деятельности!");
                                        CheckTaskStart = true;
                                        return;
                                    }

                                    UniversalLog(String.Format("Получаем списки с контрагентами. Регион: {0}; Город: {1}; Тип контрагента{2}; Вид деятельности: {3};", regionName, city, SelectedTypeKontragent, vid_deatelnosti));

                                    int breakPgain = 0;
                                    while (pagin <= Pagination)
                                    {
                                        //Сделать возможность остановки задачи 
                                        if (CheckTaskStart == true)
                                        {
                                            break;
                                        }

                                        UniversalLog(String.Format("Ждем {0} сек.", Interval));
                                        Thread.Sleep(Interval * 1000);

                                        string Code1 = String.Empty;
                                        string Code2 = String.Empty;
                                        string SelectedActivityName = String.Empty;

                                        if (itemActivity != null)
                                        {
                                            Code1 = itemActivity.Code1;
                                            Code2 = itemActivity.Code2;
                                            SelectedActivityName = itemActivity.Name;
                                        }

                                        company = sbis.GetListContragent(key, SelectedActivityName, Code1, Code2, itemRegion.Code1, kodeCity, itemRegion.IdRegion, SelectedTypeKontragent, SelectedStatus, city, pagin, SelectedOKVEDCheckBox, "", "",
                "");

                                        if (company == null)
                                        {
                                            breakPgain += 1;
                                            if (breakPgain == 2)
                                            {
                                                break;
                                            }
                                        }
                                        if (company == null)
                                        {
                                            break;
                                        }
                                        if (company.result == null)
                                        {
                                            breakPgain += 1;
                                            if (breakPgain == 2)
                                            {
                                                break;
                                            }
                                            continue;
                                        }

                                        if (company.result.d.Count == 0)
                                        {
                                            UniversalLog("Страниц с контрагентами больше нет.");
                                            break;
                                        }

                                        //Получаем индекс выручки.
                                        int revenuesIndex = company.result.s.FindIndex(s => s.n.Contains("Выручка"));
                                        //Записываем полученные id_sp, для парсинга через продолжение.
                                        foreach (var itemId_is in company.result.d)
                                        {
                                            if (DiapozonRevenueFilter)
                                            {
                                                if (revenuesIndex != -1)
                                                {
                                                    long revenue = Convert.ToInt64(itemId_is[revenuesIndex].ToString());
                                                    if (revenue != 0)
                                                    {
                                                        if (RevenueMin <= revenue && revenue <= RevenueMax)
                                                        {
                                                            WriteXmlIdSp(itemId_is[0].ToString().ToString(), itemRegion.Name);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                WriteXmlIdSp(itemId_is[0].ToString().ToString(), itemRegion.Name);
                                            }
                                        }
                                        //
                                        listCompany.Add(company);
                                        pagin += 1;
                                        UniversalLog(String.Format("Пагинация - {0} завершена", pagin));
                                    }
                                }
                            }
                        }
                    }

                    CheckTaskStart = true;
                    FillCountFooter();
                    MessageBox.Show("Получение данных idSp завершено");

                });
            }
        }


        private void ContiniueParserExecute()
        {
            MessageBoxResult result = MessageBox.Show("Очистить Кэш?", "", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    XDocument xdoc = new XDocument(new XElement("Table"));
                    xdoc.Save(@"Data/cache.xml");

                    break;
                case MessageBoxResult.No:

                    break;
                case MessageBoxResult.Cancel:
                    return;
            }

            Task.Factory.StartNew(() =>
            {
                CheckTaskStart = false;

                XmlDocument _doc = new XmlDocument();
                _doc.Load(@"Data/id_sp.xml");

                XmlNodeList idList = _doc.GetElementsByTagName("id");
                XmlNodeList idRegion = _doc.GetElementsByTagName("region_name");

                for (int i = 0; i < idList.Count; i++)
                {
                    //Сделать возможность остановки задачи 
                    if (CheckTaskStart == true)
                    {
                        break;
                    }

                    XmlDocument _docCheck = new XmlDocument();
                    _docCheck.Load(@"Data/cache.xml");
                    XmlNode root = _docCheck.DocumentElement;

                    XmlNode find_idsp = root.SelectSingleNode(String.Format("CompanyTable[id_sp='{0}']", idList[i].InnerXml.ToString()));
                    xmlExecute.DeleteIdSpXml(idList[i].InnerXml.ToString());
                    if (find_idsp != null)
                    {
                        UniversalLog(String.Format("Найдено совпадение id_sp!!!"));
                        continue;
                    }

                    int id_spp = int.Parse(idList[i].InnerXml.ToString());
                    string regionName = idRegion[i].InnerXml.ToString();
                    UniversalLog(String.Format("Ждем {0} сек.", Interval));
                    Thread.Sleep(Interval * 1000);

                    ResultDetailCompany one = sbis.GetDetailContragent(id_spp, Properties.Settings.Default.session_id);

                    if (one == null)
                    {
                        continue;
                    }
                    if (IsCertificateChecked)
                    {
                        UniversalLog(String.Format("Получаем сертификаты. Ждем {0} сек.", Interval));
                        Thread.Sleep(Interval * 1000);
                        ResultCertificate certificate = sbis.GetCertificate(id_spp, Properties.Settings.Default.session_id);
                        one.certificate = certificate;
                    }

                    if (IsOverrideChecked)
                    {
                        UniversalLog(String.Format("Получаем учредителей. Ждем {0} сек.", Interval));
                        Thread.Sleep(Interval * 1000);
                        one.founder = sbis.GetOverride(id_spp, Properties.Settings.Default.session_id);
                    }

                    UniversalLog(String.Format("Получена информация - {0}", one.result.d[8].ToString()));

                    //****************************************************************************************
                    string phone = String.Empty;
                    string companyName = String.Empty;
                    string mail = String.Empty;
                    string site = String.Empty;
                    string reabilty = String.Empty;
                    string inn = String.Empty;
                    string amountWorker = String.Empty;//Количество работников
                    string kpp = String.Empty;
                    string dataRegistration = String.Empty;
                    string adress = String.Empty;//Юридический Адрес
                    string okvd = String.Empty;
                    string all_okvd = String.Empty;//Все ОКВД
                    string kindofactivity = String.Empty;
                    string description = String.Empty;
                    string revenues = String.Empty;//Выручка
                    string index = String.Empty;
                    string citys = String.Empty;
                    string bik = String.Empty;
                    string ogrn = String.Empty;
                    string okpo = String.Empty;
                    string bank = "-";
                    string property = String.Empty;
                    string fax = String.Empty;
                    string region = String.Empty;
                    string genDirector = String.Empty;
                    string foundersp = String.Empty;
                    string certificatep = String.Empty;


                    //Список лицензий ЛО-50-01-002203 от 27.06.12 действует до 27.06.12
                    if (one.certificate != null)
                    {
                        foreach (var certifitem in one.certificate.result.d)
                        {
                            certificatep += String.Format("{0} от {1} действует до {2} \n", certifitem[1], certifitem[3], certifitem[4]);
                        }
                    }
                    else
                    {
                        certificatep = "-";
                    }
                    //Список соучередителей

                    if (one.founder != null)
                    {

                        foreach (var founderitem in one.founder.result.d)
                        {
                            if (founderitem[1] == null)
                            {
                                continue;
                            }
                            if (founderitem[1].ToString().IndexOf("Капитал", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                continue;
                            }
                            region = one.founder.result.d[0][8].ToString();
                            foundersp += String.Format("{0}, ИНН:{1}, Сумма:{2}, Доля:{3}, Вышел из состава: {4} \n", founderitem[1] ?? "Нет", founderitem[2] ?? "Нет", founderitem[3] ?? "Нет", founderitem[4] ?? "Нет", founderitem[4] ?? "Нет");
                        }
                    }
                    else
                    {
                        foundersp = "-";
                    }

                    if (one.result.d[43] != null)
                    {
                        fax = one.result.d[43].ToString();
                    }
                    else
                    {
                        fax = "-";
                    }

                    if (one.result.d[71] != null)
                    {
                        bik = one.result.d[71].ToString();
                    }
                    else
                    {
                        bik = "-";
                    }

                    if (one.result.d[4] != null)
                    {
                        okpo = one.result.d[4].ToString();
                    }
                    else
                    {
                        okpo = "-";
                    }

                    if (one.result.d[3] != null)
                    {
                        ogrn = one.result.d[3].ToString();
                    }
                    else
                    {
                        ogrn = "-";
                    }

                    if (one.result.d[54] != null)
                    {
                        genDirector = String.Format("{0} {1} {2}", one.result.d[54] ?? "", one.result.d[55] ?? "", one.result.d[56] ?? "");
                    }
                    else
                    {
                        genDirector = "-";
                    }

                    if (one.result.d[8] != null)
                    {
                        companyName = one.result.d[8].ToString();
                    }
                    else
                    {
                        companyName = "-";
                    }

                    //Количество работников
                    int amountIndex = one.result.s.FindIndex(s => s.n.Contains("КоличествоСотрудников"));
                    if (amountIndex != -1)
                    {
                        if (one.result.d[amountIndex] != null)
                        {
                            amountWorker = one.result.d[amountIndex].ToString();
                        }
                        else
                        {
                            amountWorker = "-";
                        }
                    }

                    else
                    {
                        amountWorker = "-";
                    }

                    //Все ОКВД
                    int amountallokvdIndex = one.result.s.FindIndex(s => s.n.Contains("ОКВЭДЕГРЮЛ"));
                    if (amountIndex != -1)
                    {
                        if (one.result.d[amountallokvdIndex] != null)
                        {
                            all_okvd = one.result.d[amountallokvdIndex].ToString();
                        }
                        else
                        {
                            all_okvd = "-";
                        }
                    }
                    else
                    {
                        all_okvd = "-";
                    }

                    if (one.result.d[65] != null)
                    {
                        kindofactivity = one.result.d[65].ToString();
                    }
                    else
                    {
                        kindofactivity = "-";
                    }

                    if (one.result.d[64] != null)
                    {
                        okvd = one.result.d[64].ToString();
                    }
                    else
                    {
                        okvd = "-";
                    }

                    if (one.result.d[50] != null)
                    {
                        adress = one.result.d[50].ToString();
                    }
                    else
                    {
                        adress = "-";
                    }


                    if (one.result.d[46] != null)
                    {
                        phone = one.result.d[46].ToString();
                    }
                    else
                    {
                        phone = "-";
                    }

                    if (one.result.d[44] != null)
                    {
                        mail = one.result.d[44].ToString();
                    }
                    else
                    {
                        mail = "-";
                    }

                    if (one.result.d[24] != null)
                    {
                        property = one.result.d[24].ToString();
                    }
                    else
                    {
                        property = "-";
                    }

                    if (one.result.d[42] != null)
                    {
                        site = one.result.d[42].ToString();
                    }
                    else
                    {
                        site = "-";
                    }
                    if (one.result.d[68] != null)
                    {
                        reabilty = one.result.d[68].ToString();
                    }
                    else
                    {
                        reabilty = "-";
                    }

                    if (one.result.d[1] != null)
                    {
                        inn = one.result.d[1].ToString();
                    }
                    else
                    {
                        inn = "-";
                    }

                    if (one.result.d[2] != null)
                    {
                        kpp = one.result.d[2].ToString();
                    }
                    else
                    {
                        kpp = "-";
                    }

                    if (one.result.d[21] != null)
                    {
                        dataRegistration = one.result.d[21].ToString();
                    }
                    else
                    {
                        dataRegistration = "-";
                    }

                    if (one.result.d[82] != null)
                    {
                        description = one.result.d[82].ToString();
                        description = description.Trim(new Char[] { '[', ']' });
                        description = description.Trim();
                        description = Regex.Replace(description, "[\r\n s, d , {,},[], _type, record]+", "");
                    }
                    else
                    {
                        description = "-";
                    }
                    /*
                    if (one.result.d[95] != null)123
                    {
                        revenues = one.result.d[95].ToString();
                    }
                    else
                    {
                        revenues = "-";
                    }
                    */

                    //Выручка
                    int revenuesIndex = one.result.s.FindIndex(s => s.n.Contains("Выручка"));
                    if (revenuesIndex != -1)
                    {
                        if (one.result.d[revenuesIndex] != null)
                        {
                            revenues = one.result.d[revenuesIndex].ToString();
                        }
                        else
                        {
                            revenues = "-";
                        }
                    }

                    else
                    {
                        revenues = "-";
                    }

                    String[] substrings = adress.Split(',');

                    if (substrings.Count() == 0)
                    {
                        index = "-";
                        citys = "-";
                    }
                    else
                    {
                        foreach (string cityItem in substrings)
                        {
                            if (cityItem.Contains("г.") || cityItem.Contains("с."))
                            {
                                citys = cityItem;
                                break;
                            }
                            else
                            {
                                if (SelectedCity != null)
                                {
                                    citys = SelectedCity.Name;
                                }
                                else
                                {
                                    citys = "-";
                                }
                            }

                        }
                    }


                    Regex regexIndex = new Regex(@"[0-9]{6}");

                    foreach (Match match in regexIndex.Matches(adress))
                    {
                        index = match.Groups[0].Value;
                        break;
                    }

                    xmlExecute.WriteXmlDetailCompany(new DataParsingItem(one.result.d[0].ToString(), companyName, kindofactivity, okvd, all_okvd, amountWorker, citys,
                    adress, index, phone, mail, site, revenues.ToString(), reabilty, inn, kpp, "Финансовый анализ", description, dataRegistration, bik, ogrn, okpo, bank, property, fax, regionName, genDirector, foundersp, certificatep));



                    //Сделать возможность остановки задачи 
                    if (CheckTaskStart == true)
                    {
                        break;
                    }

                }
                FillCountFooter();
                MessageBox.Show("Получение данных завершено");
                CheckTaskStart = true;
            });

        }

        private void StartSearchCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("Очистить историю?", "", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    XDocument xdoc = new XDocument(new XElement("Table"));
                    xdoc.Save(@"Data/id_sp.xml");
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }

            if (Search == null)
            {
                return;
            }

            Task.Factory.StartNew(() =>
            {
                CheckTaskStart = false;
                string[] words = Search.Split(';');
                foreach (string word in words)
                {
                    if (word == "")
                    {
                        continue;
                    }

                    string key = Properties.Settings.Default.session_id;
                    Key_api = key;
                    ResultCompany company = new ResultCompany();

                    UniversalLog(String.Format("Получаем - {0}", word));
                   
                    int pagin = 0;
                    int breakPgain = 0;

                    while (pagin <= Pagination)
                    {
                        //Сделать возможность остановки задачи 
                        if (CheckTaskStart == true)
                        {
                            break;
                        }

                        UniversalLog(String.Format("Ждем {0} сек.", Interval));
                        Thread.Sleep(Interval * 1000);
                        company = sbis.SearchListContragent(key, word, pagin);

                        if (company == null)
                        {
                            breakPgain += 1;
                            if (breakPgain == 2)
                            {
                                break;
                            }
                        }
                        if (company == null)
                        {
                            break;
                        }
                        if (company.result == null)
                        {
                            breakPgain += 1;
                            if (breakPgain == 2)
                            {
                                break;
                            }
                            continue;
                        }

                        if (company.result.d.Count == 0)
                        {
                            UniversalLog("Страниц с контрагентами больше нет. Переходим к получению информаций о контрагенте");
                            break;
                        }

                        //Записываем полученные id_sp, для парсинга через продолжение.
                        foreach (var itemId_is in company.result.d)
                        {
                            WriteXmlIdSp(itemId_is[0].ToString().ToString(), String.Format("Поисковой запрос: {0}", word));
                        }

                        pagin += 1;
                        UniversalLog(String.Format("Пагинация - {0} завершена", pagin));
                    }
                }

                CheckTaskStart = true;
                MessageBox.Show("Получение данных idSp завершено");
            });
        }

        private void FillCountFooter()
        {
            XDocument xdocId = XDocument.Load(@"Data/id_sp.xml");
            XDocument xdocContragent = XDocument.Load(fileCashePath);
            CountFilter = xdocId.Descendants("id").Count();
            CountContragent = xdocContragent.Descendants("id_sp").Count();

        }

        #region Navigation

        private void NavigateSettings()
        {
            Model._HomePage = new Uri("/ParserSbis;component/Views/_SettingsPage.xaml", UriKind.Relative);
        }

        private void NavigateLog()
        {
            Model._HomePage = new Uri("/ParserSbis;component/Views/_LogPage.xaml", UriKind.Relative);
        }

        /// <summary>
        /// Navigates the Search Page.
        /// </summary>
        private void NavigateSearch()
        {
            Model._HomePage = new Uri("/ParserSbis;component/Views/_SearchPage.xaml", UriKind.Relative);
        }

        /// <summary>
        /// Navigates the Filter Page.
        /// </summary>
        private void NavigateFilter()
        {
            Model._HomePage = new Uri("/ParserSbis;component/Views/_HomePage.xaml", UriKind.Relative);
        }

        private void NavigateHome()
        {
            Model._HomePage = new Uri("/ParserSbis;component/Views/_HomePage.xaml", UriKind.Relative);
        }

        #endregion Navigation

        private void SaveXmlToCsvExecute()
        {
            xmlExecute.SaveXmlToCsv();
        }

        private void AddActivivityDialogExecute()
        {
            DialogService.Instance.ShowDialogAcvivityDialog();
        }

        private void AddRegionDialogExecute()
        {
            DialogService.Instance.ShowDialogRegionDialog();
        }

        internal void UniversalLog(string message)
        {
            SimpleIoc.Default.GetInstance<eventsLog>().UniversalLog(message);
        }
    }
}
