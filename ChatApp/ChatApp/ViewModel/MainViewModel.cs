using ChatApp.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        private BaseViewModel _selectedViewModel = new ViewModel.HomeViewModel();

        private bool darkMode;
        public bool IsTrue { get; set; }
        public bool DarkMode
        {
            get { return darkMode; }
            set
            {
                darkMode = value;
            }
        }

        public MainViewModel(bool isTrue)
        {
            IsTrue = isTrue;
            DarkMode = false;
        }


        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            LanguageSetCommand = new Commands.CommandManager(languageSet);
        }

        public void languageSet()
        {
            if (Settings1.Default.CurrentLanguage == "hu-HU")
                Settings1.Default.CurrentLanguage = "en-GB";
            else
                Settings1.Default.CurrentLanguage = "hu-HU";

            Settings1.Default.Save();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
                
        }

        
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }
        public ICommand UpdateViewCommand { get; set; }

        public Commands.CommandManager LanguageSetCommand { get; }

        public string CurrentLangMsg { get; set; }


    }



}

