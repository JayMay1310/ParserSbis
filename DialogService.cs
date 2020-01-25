using ParserSbis.Dialog;
using ParserSbis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParserSbis
{
    public class DialogService
    {
        #region Member Variables

        private static volatile DialogService instance;
        private static object syncroot = new object();

        #endregion

        #region Ctr

        private DialogService()
        {

        }

        #endregion

        #region Public Methods

        /*public void ShowDialog(object _callerContentOne, object _callerContentTwo)
        {
            DialogViewModel viewmodel = new DialogViewModel(_callerContentOne, _callerContentTwo);
            DialogView view = new DialogView();
            view.DataContext = viewmodel;
            view.ShowDialog();
        }*/
        /// <summary>
        /// Option Dialog
        /// </summary>
        /// <param name="viewModel"></param>
        public void ShowOptionDialog(MainViewModel viewModel)
        {
            DialogOptionView dialog = new DialogOptionView() { DataContext = viewModel };
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }

        /// <summary>
        /// Task Dialog
        /// </summary>
        public void ShowTaskDialog(TaskViewModel viewModel)
        {
            DialogTaskView dialog = new DialogTaskView() { DataContext = viewModel };
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }

        /// <summary>
        /// Диалог с ввыбранными видами деятельности. 
        /// </summary>
        public void ShowDialogAcvivityDialog()
        {
            DialogAcvivityView dialog = new DialogAcvivityView() { };
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }
        
        public void ShowDialogRegionDialog()
        {
            DialogRegionView dialog = new DialogRegionView() { };
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }


        #endregion

        #region Private Methods

        #endregion

        #region Properties

        public static DialogService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncroot)
                    {
                        if (instance == null)
                        {
                            instance = new DialogService();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion
    }
}
