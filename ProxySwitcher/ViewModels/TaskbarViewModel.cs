using ProxySwitcher.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySwitcher.ViewModels
{
    public class TaskbarViewModel
    {
        private ObservableCollection<ProxyProfile> _allProfiles;
        public ObservableCollection<ProxyProfile> AllProfiles
        {
            get
            {
                return _allProfiles;
            }
            set
            {
                _allProfiles = value;
            }
        }

        public void SetCurrentProfile(ProxyProfile Profile)
        {

        }

        public void Exit()
        {
            Exit();
        }

        public void OpenWindow()
        {

        }

        public TaskbarViewModel()
        {
            _allProfiles = new ObservableCollection<ProxyProfile>();
        }
    }
}
