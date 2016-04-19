using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProxySwitcher.Model
{
    public class StateManager
    {
        private readonly string _stateFile;
        private Database _db;

        public StateManager()
        {
            _stateFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProxySwitcher.state");
            //_stateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProxySwitcher.state");
            Deserialize();
        }

        public Database ProxySwitcherDB
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        private void Deserialize()
        {
            if (File.Exists(_stateFile))
            {
                try
                {
                    FileStream stream = File.Open(_stateFile, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();
                    _db = (Database)formatter.Deserialize(stream);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Could not read database!");
                    
                }

            }
            else _db = new Database();

            if(_db.AllProxyProfiles == null)
            {
                _db.AllProxyProfiles = new ObservableCollection<ProxyProfile>();
            }
        }

        private void Serialize()
        {
            try
            {
                FileStream stream = File.Open(_stateFile, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _db);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Could not serialize database!");
                File.Delete(_stateFile);
            }

        }

        public void SaveDatabase()
        {
            Serialize();
        }

        public void AddProfile(ProxyProfile profile)
        {
            _db.AllProxyProfiles.Add(profile);
        }

        public void EditProfile(ProxyProfile profile)
        {
            int index;
            index = _db.AllProxyProfiles.IndexOf(
                _db.AllProxyProfiles.Where(x => x.Name == profile.Name).FirstOrDefault()
                );

            _db.AllProxyProfiles.RemoveAt(index);
            _db.AllProxyProfiles.Insert(index, profile);

        }

        public void RemoveProfile(ProxyProfile profile)
        {
            _db.AllProxyProfiles.Remove(
                _db.AllProxyProfiles.Where(x => x.Name == profile.Name).FirstOrDefault()
                );
        }

        public ProxyProfile GetProfile(ProxyProfile profile)
        {
            return _db.AllProxyProfiles.Where(x => x.Name == profile.Name).FirstOrDefault();
        }

        public ProxyProfile GetProfile(string Name)
        {
            return _db.AllProxyProfiles.Where(x => x.Name == Name).FirstOrDefault();
        }

 
    }
}
