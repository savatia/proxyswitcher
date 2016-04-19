using ProxySwitcher.Model;
using ProxySwitcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProxySwitcher.Resources
{
    partial class NotifyIconResources : ResourceDictionary
    {
        public NotifyIconResources()
        {
            InitializeComponent();
        }


        private void ProfileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AppViewModel vm = (AppViewModel)NotifyIcon.DataContext;
            MenuItem obMenuItem = e.OriginalSource as MenuItem;
            ProxyProfile p = (ProxyProfile)(obMenuItem.DataContext);
            vm.ChangeProxy(p);
        }

        private void RemoveProxyButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            AppViewModel vm = (AppViewModel)NotifyIcon.DataContext;
            vm.RemoveProxy();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void ForceRedrawWindowWithHack(UIElement element)
        {
            Action emptyAction = delegate { };
            element.Dispatcher.Invoke(DispatcherPriority.Render, emptyAction);
        }


    }
}
