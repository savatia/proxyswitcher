using Hardcodet.Wpf.TaskbarNotification;
using ProxySwitcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProxySwitcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                notifyIcon.Dispose();
            }
            catch(NullReferenceException )
            {

            }
            base.OnExit(e);
        }
    }
}
