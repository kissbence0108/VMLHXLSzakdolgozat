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

