using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using ParserSbis.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;

namespace ParserSbis.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TaskViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public static CollectionViewSource view = new CollectionViewSource();
        public ObservableCollection<TaskObject> TaskList { get; set; }

        public ICommand SelectAll { get; private set; }

        /// <summary>
        /// Initializes a new instance of the TaskViewModel class.
        /// </summary>
        public TaskViewModel(IDataService dataService, ObservableCollection<TaskObject> orgs)
        {

            _dataService = dataService;
            view.Source = orgs;

            TaskList = orgs;

            SelectAll = new RelayCommand(() => SelectAllExecute(), () => true);
        }

        private void SelectAllExecute()
        {
            foreach (TaskObject item in view.View)
            {
                item.Value = true;
            }
            view.View.Refresh();
        }
    }
}