using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class NotificationsController
    {

        public NotificationsService service;

        public NotificationsController()
        {
            service = new NotificationsService();
        }

        public ObservableCollection<NotificationsDTO> findByIdPatient(int idPatient)
        {
            ObservableCollection<NotificationsDTO> patientsNotification = new ObservableCollection<NotificationsDTO>();
            ObservableCollection<Notifications> founded = service.findNotificationsByIdPatient(idPatient);

            foreach(Notifications n in founded)
            {
                patientsNotification.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person, n.IdPatient));
            }
            return patientsNotification;
        }
        public ObservableCollection<NotificationsDTO> getAll()
        {
            List<Notifications> all = service.getAll();
            ObservableCollection<NotificationsDTO> allNotifications = new ObservableCollection<NotificationsDTO>();
            foreach(Notifications n in all)
            {
                allNotifications.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person, n.IdPatient));
            }
            return allNotifications;
        }
        public ObservableCollection<NotificationsDTO> loadNotificationsByPerson(String person)
        {
            ObservableCollection<NotificationsDTO> notifications = new ObservableCollection<NotificationsDTO>();
            ObservableCollection<Notifications> allNotifications = service.loadNotificationsByPerson(person);

            foreach(Notifications n in allNotifications)
            {
                notifications.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person));
            }
            return notifications;
        }

        public int generisiId()
        {
            int ret = 0;

            List<Notifications> allNotifications = service.getAll();

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

        public void createNotification(NotificationsDTO notification)
        {
            Notifications newNotification = new Notifications(notification.Title, notification.Content, notification.Date, generisiId(), notification.Person);
            service.createNotification(newNotification);
        }
        public void createNotificationForPatient(NotificationsDTO notification)
        {
            Notifications newNotification = new Notifications(notification.Title, notification.Content, notification.Date, generisiId(), notification.Person, notification.IdPatient);
            service.createNotificationForPatient(newNotification);
        }

        public void deleteNotification(NotificationsDTO notification)
        {
            Notifications forDelete = new Notifications(notification.Title, notification.Content, notification.Date, notification.Id, notification.Person);
            service.deleteNotification(forDelete);
        }
    }
}
