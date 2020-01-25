using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ParserSbis.ViewModel.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the facade view model.
        /// </summary>
        public FacadeViewModel FacadeViewModel { get; set; }

        /// <summary>
        /// Views the model base.
        /// </summary>
        /// <param name="FacadeViewModel">The facade view model.</param>
        /// <returns></returns>
        public ViewModelBase(FacadeViewModel FacadeViewModel)
        {
            this.FacadeViewModel = FacadeViewModel;
        }

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