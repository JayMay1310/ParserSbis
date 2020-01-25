using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSbis.Models
{
    public class MainWindowModel : ModelBase
    {
        private bool _mainWindowVisible;
        public bool MainWindowVisible
        {
            get { return _mainWindowVisible; }
            set
            {
                _mainWindowVisible = value;
                OnPropertyChanged();
            }
        }

        #region Page Properties

        private Uri _menuPage;
        public Uri _MenuPage
        {
            get { return _menuPage; }
            set
            {
                _menuPage = value;
                OnPropertyChanged();
            }
        }

        private Uri _homePage;
        public Uri _HomePage
        {
            get { return _homePage; }
            set
            {
                _homePage = value;
                OnPropertyChanged();
            }
        }

        private Uri _footerPage;
        public Uri _FooterPage
        {
            get { return _footerPage; }
            set
            {
                _footerPage = value;
                OnPropertyChanged();
            }
        }

        #endregion Page Properties



        public static MainWindowModel GetModel()
        {
            MainWindowModel model = new MainWindowModel();
            model.MainWindowVisible = false;
            model._MenuPage = new Uri("/ParserSbis;component/Views/_MenuPage.xaml", UriKind.Relative);
            model._HomePage = new Uri("/ParserSbis;component/Views/_HomePage.xaml", UriKind.Relative);
            model._FooterPage = new Uri("/ParserSbis;component/Views/_FooterPage.xaml", UriKind.Relative);
            return model;
        }
    }
}
