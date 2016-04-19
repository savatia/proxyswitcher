using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySwitcher.Model
{
    [Serializable]
    public class Database
    {
        public ObservableCollection<ProxyProfile> AllProxyProfiles
        {
            get; set;
        }  
    }
}
