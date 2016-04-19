using System.Windows;
using ProxySwitcher.Model;

namespace ProxySwitcher.Views
{
    /// <summary>
    /// Interaction logic for EditProfileDialog.xaml
    /// </summary>
    public partial class EditProfileDialog : Window
    {
        private MainWindow _mainWindow;
        private ProxyProfile _proxyProfile = null;
        public EditProfileDialog( MainWindow mainWindow, ProxyProfile proxyProfile)
        {
            InitializeComponent();
            _proxyProfile = proxyProfile;
            _mainWindow = mainWindow;
        }

        public EditProfileDialog(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.RecieveProfile(new ProxyProfile(NameTextBlock.Text)
            {
                AutomaticScript = AScriptTextBlock.Text,
                ProxyAddress = ProxyTextBlock.Text,
                Port = PortTextBlock.Text
            }
            );
            Close();
        }
    }
}
