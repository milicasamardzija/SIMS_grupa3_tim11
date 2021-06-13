using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.MVVM.ModelView
{
    public class ModelViewObavestenja
    {
        private NotificationsController controller = new NotificationsController();
        public ObservableCollection<NotificationsDTO> Notifications { get; set; }
        public ModelViewObavestenja()
        {
           Notifications = new ObservableCollection<NotificationsDTO>(controller.getNotifications("Upravnik"));
        }
    }
}
