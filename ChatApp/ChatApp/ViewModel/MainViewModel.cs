using ChatApp.Commands;
using System;
using System.Collections.Generic;
using System.Text;
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
        }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }
        public ICommand UpdateViewCommand { get; set; }


    }



}

