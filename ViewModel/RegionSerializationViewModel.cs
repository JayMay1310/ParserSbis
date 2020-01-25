using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParserSbis.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ParserSbis.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RegionSerializationViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public ICommand SelectAllCommand { get; private set; }
        public ICommand UpdateRegionCommand { get; private set; }

        public static CollectionViewSource viewRegion = new CollectionViewSource();
        public ObservableCollection<RegionItem> RegionList { get; set; }


        /// <summary>
        /// Initializes a new instance of the RegionSerializationViewModel class.
        /// </summary>
        public RegionSerializationViewModel()
        {
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

                    RegionList = new ObservableCollection<RegionItem>(model.Select(b => new RegionItem(b.Value, b.IdRegion, b.Name, b.Code1, b.Code2, b.Code3, b.Code4, b.Code5)));
                    viewRegion.Source = RegionList;

                });

            UpdateRegionCommand = new RelayCommand(() => UpdateRegionExecute(), () => true);
            SelectAllCommand = new RelayCommand(() => SelectAllExecute(), () => true);
        }

        private void UpdateRegionExecute()
        {
            List<RegionItem> regionSerialize = new List<RegionItem>();
            foreach (var item in RegionList)
            {
                if (item.Value == true)
                {
                    regionSerialize.Add(item);
                }
            }

            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("region.xml"))
            {
                serializer.Serialize(fs, regionSerialize);
            }

            MessageBox.Show("Список выбранных регионов обновлен");
        }

        private void SelectAllExecute()
        {
            foreach (RegionItem item in viewRegion.View)
            {
                item.Value = true;
            }

            viewRegion.View.Refresh();
        }

    }
}