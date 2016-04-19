using ProxySwitcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProxySwitcher.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        protected AppViewModel _appViewModel;
        public SettingsView(AppViewModel appViewModel)
        {
            DataContext = _appViewModel = appViewModel;
            InitializeComponent();

            UpdateControls();
        }

        private void StartupCheckBox_Click(object sender, RoutedEventArgs e)
        {
            _appViewModel.RunOnStartup(StartupCheckBox.IsChecked.Value);
        }

        private void UpdateControls()
        {
            UpdateStartupCheckbox();
        }

        private void UpdateStartupCheckbox()
        {
            StartupCheckBox.IsChecked = _appViewModel.CanRunOnStartUp();
        }
    }
}
