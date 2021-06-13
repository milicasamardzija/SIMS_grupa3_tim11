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

        public List<NotificationsDTO> findByIdPatient(int idPatient)
        {
            List<NotificationsDTO> patientsNotification = new List<NotificationsDTO>();
            List<Notifications> founded = service.findNotificationsByIdPatient(idPatient);

            foreach(Notifications n in founded)
            {
                patientsNotification.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person, n.IdPatient));
            }
            return patientsNotification;
        }

        public List<NotificationsDTO> getNotifications(string person)
        {
            List<NotificationsDTO> allNotifications = new List<NotificationsDTO>();
            foreach (Notifications n in service.getNotifications(person))
            {
                allNotifications.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person, n.IdPatient));
            }
            return allNotifications;
        }

        public List<NotificationsDTO> getAll()
        {
            List<Notifications> all = service.getAll();
            List<NotificationsDTO> allNotifications = new List<NotificationsDTO>();
            foreach(Notifications n in all)
            {
                allNotifications.Add(new NotificationsDTO(n.Title, n.Content, n.Date, n.Id, n.Person, n.IdPatient));
            }
            return allNotifications;
        }
        public List<NotificationsDTO> loadNotificationsByPerson(String person)
        {
            List<NotificationsDTO> notifications = new List<NotificationsDTO>();
            List<Notifications> allNotifications = service.loadNotificationsByPerson(person);

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
