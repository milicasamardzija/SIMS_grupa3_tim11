using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;

namespace Hospital.Model
{
   public  class NotificationsFileStorage : GenericFileStorage<Notifications>, INotificationsFileStorage
    {
        public NotificationsFileStorage(String filePath) : base(filePath) { }

        //dodala da svako moze da ocita svoje 
        public ObservableCollection<Notifications> FindByPerson(String person)
        {
            List<Notifications> allNotifications = GetAll();
            ObservableCollection<Notifications> all = new ObservableCollection<Notifications>(allNotifications);
            ObservableCollection<Notifications> ret = new ObservableCollection<Notifications>();

            foreach (Notifications n in all)
            {
                if (n.Person == person)
                {
                    ret.Add(n);

                }
            }

            return ret;
        }

        public ObservableCollection<Notifications> FindByIdPatient(int idPatient)
        {
            List<Notifications> all = GetAll();
            ObservableCollection<Notifications> allNootifications = new ObservableCollection<Notifications>(all);
            ObservableCollection<Notifications> ret = new ObservableCollection<Notifications>();

            foreach (Notifications n in all)
            {
                if (n.IdPatient == idPatient)
                {
                    ret.Add(n);

                }
            }

            return ret;
        }
    }
}
