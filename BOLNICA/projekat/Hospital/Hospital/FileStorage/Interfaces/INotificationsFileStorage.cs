using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface INotificationsFileStorage : GenericRepository<Notifications>
    {
        ObservableCollection<Notifications> FindByPerson(String person);
        ObservableCollection<Notifications> FindByIdPatient(int idPatient);
    }
}
