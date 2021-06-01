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
        public List<Notifications> FindByPerson(String person)
        {
            List<Notifications> allNotifications = GetAll();
            List<Notifications> ret = new List<Notifications>();

            foreach (Notifications n in allNotifications)
            {
                if (n.Person == person)
                {
                    ret.Add(n);

                }
            }
            return ret;
        }

        public List<Notifications> FindByIdPatient(int idPatient)
        {
            List<Notifications> all = GetAll();
            List<Notifications> ret = new List<Notifications>();

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
