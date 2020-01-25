using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParserSbis.Model;
using System;
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
    public class SerializationViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public ICommand SelectAllCommand { get; private set; }
        public ICommand UpdateActivityCommand { get; private set; }

        public static CollectionViewSource viewActivity = new CollectionViewSource();
        public ObservableCollection<ActivityItem> ActivityList { get; set; }

        /// <summary>
        /// Initializes a new instance of the SerializationViewModel class.
        /// </summary>
        public SerializationViewModel()
        {
            IDataService _dataService = new DataService();

            _dataService.GetDataActivity(
                (model_activity, error) =>
                {
                if (error != null)
                {
                    // Report error here
                    return;
                }

                    ActivityList = new ObservableCollection<ActivityItem>(model_activity.Select(b => new ActivityItem(b.Value, b.IdRegion, b.Name, b.Code1, b.Code2, b.Code3, b.Code4, b.Code5)));
                    viewActivity.Source = ActivityList;
                });

            SelectAllCommand = new RelayCommand(() => SelectAllExecute(), () => true);
            UpdateActivityCommand = new RelayCommand(() => UpdateActivityExecute(), () => true);

            //ReadSelectActvivity();
        }

        private void SelectAllExecute()
        {
            foreach (ActivityItem item in viewActivity.View)
            {
                item.Value = true;
            }

            viewActivity.View.Refresh();
        }
        
        private void UpdateActivityExecute()
        {
            List<ActivityItem> activitySerialize = new List<ActivityItem>();
            foreach (var item in ActivityList)
            {
                if (item.Value == true)
                {
                    activitySerialize.Add(item);

                }
            }


            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("activity.xml"))
            {
                serializer.Serialize(fs, activitySerialize);
            }


            MessageBox.Show("Список 'Вид деятельности' обновлен. ");
        }

        private void ReadSelectActvivity()
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            List<RegionItem> clonedUsers = null;
            using (FileStream fs = File.OpenRead("activity.xml"))
            {
                clonedUsers = (List<RegionItem>)serializer.Deserialize(fs);
            }
        }
    }
}