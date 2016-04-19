using Hardcodet.Wpf.TaskbarNotification;
using ProxySwitcher.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProxySwitcher.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private static AppViewModel _currentViewModel = null;

        private StateManager _stateManager;

        public ObservableCollection<ProxyProfile> AllProfiles
        {
            get
            {
                return  _stateManager.ProxySwitcherDB.AllProxyProfiles;
            }
        }

        MainWindow _mainWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public static AppViewModel GetCurrent(MainWindow mainWindow)
        {
            if(_currentViewModel == null)
            {
                _currentViewModel = new AppViewModel(mainWindow);
            }

            return _currentViewModel;
        }

        public AppViewModel(MainWindow mainWindow)
        {
            _stateManager = new StateManager();
            _mainWindow = mainWindow;

            var notifyIcon = (TaskbarIcon)Application.Current.FindResource("NotifyIcon");
            notifyIcon.DataContext = this;
           
        }



        public void SaveProxyProfile(ProxyProfile profile)
        {
            _stateManager.AddProfile(profile);
            _stateManager.SaveDatabase();
        }

        public void ChangeProxy(ProxyProfile profile)
        {
            using (ProxyHandler handler = new ProxyHandler())
            {
                handler.ChangeProxy(profile.ProxyAddress + ":" + profile.Port);
            }

            UpdatePropertyCheckMarks();
        }

        public void RemoveProxy()
        {
            using (ProxyHandler handler = new ProxyHandler())
            {
                handler.DisableProxy();
            }

            UpdatePropertyCheckMarks();
        }

        public bool IsProxyDisabled
        {
            get
            {
                return (new ProxyHandler()).ProxyDisabled();
            }
            set
            {

            }
        }

        public void UpdatePropertyCheckMarks()
        {
            foreach (ProxyProfile p in AllProfiles)
            {
                p.NotifyPropertyChanged("IsActive");
            }

            NotifyPropertyChanged("IsProxyDisabled");
        }

        public void ShowWindow()
        {
            _mainWindow.Show();
        }

        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => ShowWindow() };
            }
        }

        public class DelegateCommand : ICommand
        {
            public Action CommandAction { get; set; }
            public Func<bool> CanExecuteFunc { get; set; }

            public void Execute(object parameter)
            {
                CommandAction();
            }

            public bool CanExecute(object parameter)
            {
                return CanExecuteFunc == null || CanExecuteFunc();
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }

        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
