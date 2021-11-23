using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var lang = ChatApp.Settings1.Default.CurrentLanguage;
            StartupUri = new Uri("View/Login.xaml", UriKind.Relative);
        }

        public App()
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.CurrentCulture;
        }
    }
}
