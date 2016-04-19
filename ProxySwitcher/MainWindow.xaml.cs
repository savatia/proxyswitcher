using System.Windows;
using ProxySwitcher.Views;
using ProxySwitcher.Model;
using ProxySwitcher.ViewModels;
using System;
using System.ComponentModel;

namespace ProxySwitcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppViewModel _appViewModel;
        public MainWindow()
        {
            DataContext = _appViewModel = AppViewModel.GetCurrent(this);
            InitializeComponent();
        }



        private void NewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            EditProfileDialog edit = new EditProfileDialog(this);
            try
            {
                edit.ShowDialog();
            }
            catch
            {

            }
        }

        public void RecieveProfile(ProxyProfile profile)
        {
            _appViewModel.SaveProxyProfile(profile);
        }

        private void ProfileListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            Hide();
        }
    }
}
