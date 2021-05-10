using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Hospital.Model
{
   public  class NotificationsFileStorage
    {

        public ObservableCollection<Notifications> GetAll()
        {
            ObservableCollection<Notifications> notifications = new ObservableCollection<Notifications>();

            notifications = JsonConvert.DeserializeObject<ObservableCollection<Notifications>>(File.ReadAllText(@"./../../../../Hospital/files/notifications.json"));
            return notifications;
        }

        public void Save(Notifications newPatient)
        {
            ObservableCollection<Notifications> sviPacijenti = GetAll();
            sviPacijenti.Add(newPatient);
            SaveAll(sviPacijenti);

        }

        public void SaveAll(ObservableCollection<Notifications> patients)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/notifications.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, patients);

            }
        }

        public void Delete(Notifications patient)
        {
            ObservableCollection<Notifications> allPatients = GetAll();

            foreach (Notifications p in allPatients)
            {
                if (p.IdNotification == patient.IdNotification)
                {
                    allPatients.Remove(p);
                    break;
                }
            }
            SaveAll(allPatients);
        }

        public void DeleteById(int id)


        {
            ObservableCollection<Notifications> allPatients = GetAll();

            foreach (Notifications patient in allPatients)
            {

                if (patient.IdNotification == id)
                {

                    allPatients.Remove(patient);
                    break;
                }
            }
            SaveAll(allPatients);
        }

        public Notifications FindById(int id)
        {
            ObservableCollection<Notifications> allPatients = GetAll();
            Notifications ret = null;

            foreach (Notifications patient in allPatients)
            {
                if (patient.IdNotification == id)
                {
                    ret = patient;
                    break;
                }
            }

            return ret;
        }

        public Boolean ExistsById(int id)
        {
            ObservableCollection<Notifications> allPatients = GetAll();
            Boolean ret = false;

            foreach (Notifications patient in allPatients)
            {
                if (patient.IdNotification == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
