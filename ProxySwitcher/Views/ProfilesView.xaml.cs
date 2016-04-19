using ProxySwitcher.Model;
using ProxySwitcher.ViewModels;
using ProxySwitcher.Views;
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
    /// Interaction logic for ProfilesView.xaml
    /// </summary>
    public partial class ProfilesView : UserControl
    {
        protected AppViewModel _appViewModel;
        public ProfilesView( AppViewModel appViewModel)
        {
            DataContext = _appViewModel = appViewModel;
            InitializeComponent();
        }
        
        private void SwitchToProfile_Click(object sender, RoutedEventArgs e)
        {
            ProxyProfile profile = (ProxyProfile)((Button)e.Source).DataContext;
            _appViewModel.ChangeProxy(profile);
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

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            ProxyProfile profile = (ProxyProfile)((Button)e.Source).DataContext;

            EditProfileDialog edit = new EditProfileDialog(this, profile);

            try
            {
                edit.ShowDialog();
            }
            catch
            {

            }
        }

        private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            ProxyProfile profile = (ProxyProfile) ( (Button)e.Source ).DataContext;
            _appViewModel.DeleteProxyProfile(profile);
        }

        public void RecieveProfile(ProxyProfile profile)
        {
            _appViewModel.SaveProxyProfile(profile);
        }

        public void RecieveChangedProfile(ProxyProfile profile)
        {
            _appViewModel.EditProxyProfile(profile);
            _appViewModel.UpdatePropertyCheckMarks();
        }
    }
}
