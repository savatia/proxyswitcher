using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySwitcher.Model
{
    [Serializable]
    public class ProxyProfile : INotifyPropertyChanged
    {
        public string AutomaticScript { get; set; }
        public string ProxyAddress { get; set; }
        public string Port { get; set; }

        public string Name { get; set; }

        [field: NonSerialized]
        public bool IsActive
        {
            get
            {
                bool isActive = false;

                ProxyHandler handler = new ProxyHandler();

                if (this == null)
                {
                    if (handler.ProxyDisabled())
                    {
                        isActive = true;
                    }
                }
                else if (handler.IsActive(this))
                {
                    isActive = true;
                }   

                return isActive;
            }
            set
            {

            }
        }
        
  
        public ProxyProfile(string name)
        {
            Name = name;
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
