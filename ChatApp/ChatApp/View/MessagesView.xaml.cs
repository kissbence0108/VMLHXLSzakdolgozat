using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ChatApp.View
{
    /// <summary>
    /// Interaction logic for MessagesView.xaml
    /// </summary>
    public partial class MessagesView : UserControl
    {
        public MessagesView()
        {
            InitializeComponent();
            DataContext = new MessagesViewModel();
            //(DataContext as MessagesViewModel).InitServer();
        }

        private void listBox1_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null || listBox.SelectedItem == null || listBox.Items == null) return;

            listBox.Items.MoveCurrentTo(listBox.SelectedItem);
            listBox.ScrollIntoView(listBox.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MessagesViewModel).RefreshMessageList();
        }
    }
}
