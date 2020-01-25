using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ParserSbis.ViewModel
{
    /// <summary>
    /// Collection Of Viewmodels.
    /// </summary>
    public class FacadeViewModel
    {
        /// <summary>
        /// The get instance
        /// </summary>
        public static FacadeViewModel GetInstance;

        public ViewModel.MainViewModel MainViewModel;


        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeViewModel"/> class.
        /// </summary>
        public FacadeViewModel()
        {
            FacadeViewModel.GetInstance = this;
        }

        /// <summary>
        /// 
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}