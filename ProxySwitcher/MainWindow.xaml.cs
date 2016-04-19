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

            Container.Content = new ProfilesView(_appViewModel);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            Hide();
        }

        private void ProfilesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowView<ProfilesView>(new ProfilesView(_appViewModel));
        }

        private void SettingssButton_Click(object sender, RoutedEventArgs e)
        {
            ShowView<SettingsView>(new SettingsView(_appViewModel));
        }

        private void AboutsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowView<AboutView>(new AboutView());
        }

        public void ShowView<T>(T view)
        {
            Container.Content = view;
        }
    }
}
