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

        public ObservableCollection<Notifications> findNotificationsByIdPatient(int id) => new ObservableCollection<Notifications>(storageNotifications.FindByIdPatient(id));

        public int generisiId()
        {
            int ret = 0;
            List<Notifications> allNotifications = storageNotifications.GetAll();
            ObservableCollection<Notifications> all = new ObservableCollection<Notifications>(allNotifications);

            foreach (Notifications nId in all)
            {
                foreach (Notifications n in all)
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

        public List<Notifications> getAll()
        {
            return storageNotifications.GetAll();
        }

        public ObservableCollection<Notifications> loadNotificationsByPerson(String person)
        {
            ObservableCollection<Notifications> notifications =new ObservableCollection<Notifications>( storageNotifications.FindByPerson(person));
            return notifications;
        }

        public void deleteNotification(Notifications notification)
        {
             storageNotifications.Delete(notification);
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
