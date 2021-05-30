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
    }
}
