using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class NotificationsService
    {

        public INotificationsFileStorage storageNotifications;
        public IPatientFileStorage storagePatients;
        public NotificationsService()
        {
            storagePatients = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            storageNotifications = new NotificationsFileStorage("./../../../../Hospital/files/notifications.json");
        }

        public List<Notifications> findNotificationsByIdPatient(int id) => new List<Notifications>(storageNotifications.FindByIdPatient(id));

        public int generateId()
        {
            int ret = 0;
            List<Notifications> allNotifications = storageNotifications.GetAll();
          
            foreach (Notifications nId in allNotifications)
            {
                foreach (Notifications n in allNotifications)
                {
                    if (ret == n.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        internal List<Notifications> getNotifications(string person)
        {
            return storageNotifications.FindByPerson(person);
        }

        public List<Notifications> getAll()
        {
            return storageNotifications.GetAll();
        }

        public List<Notifications> loadNotificationsByPerson(String person)
        {
            
            return storageNotifications.FindByPerson(person);
        }

        public void deleteNotification(Notifications notification)
        {
             storageNotifications.DeleteById(notification.Id);
        } 
        public void createNotification(Notifications notifications)
        {
            storageNotifications.Save(notifications);
        }
        public void createNotificationForPatient(Notifications notifications)
        {
            storageNotifications.Save(notifications);
        }
    }



}
