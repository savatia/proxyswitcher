using System.Windows;
using ProxySwitcher.Model;

namespace ProxySwitcher.Views
{
    /// <summary>
    /// Interaction logic for EditProfileDialog.xaml
    /// </summary>
    public partial class EditProfileDialog : Window
    {
        private ProfilesView _settingsView;
        private ProxyProfile _proxyProfile = null;
        public EditProfileDialog( ProfilesView profilesView, ProxyProfile proxyProfile)
        {
            InitializeComponent();
            _proxyProfile = proxyProfile;
            _settingsView = profilesView;

            UpdateControls();
            
        }

        public EditProfileDialog(ProfilesView ProfilesView)
        {
            InitializeComponent();
            _settingsView = ProfilesView;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(_proxyProfile == null)
            _settingsView.RecieveProfile(new ProxyProfile(NameTextBlock.Text)
            {
                AutomaticScript = AScriptTextBlock.Text,
                ProxyAddress = ProxyTextBlock.Text,
                Port = PortTextBlock.Text
            }
            );

            else
            {
                _proxyProfile.AutomaticScript = AScriptTextBlock.Text;
                _proxyProfile.ProxyAddress =  ProxyTextBlock.Text;
                _proxyProfile.Port = PortTextBlock.Text;

                _settingsView.RecieveChangedProfile(_proxyProfile);
            }
            Close();
        }

        private void UpdateControls()
        {

            AScriptTextBlock.Text = _proxyProfile.AutomaticScript;
            ProxyTextBlock.Text = _proxyProfile.ProxyAddress;
            PortTextBlock.Text = _proxyProfile.Port;
            NameTextBlock.Text = _proxyProfile.Name;

            if(_proxyProfile != null)
            {
                NameTextBlock.IsEnabled = false;
            }
        }
    }
}
