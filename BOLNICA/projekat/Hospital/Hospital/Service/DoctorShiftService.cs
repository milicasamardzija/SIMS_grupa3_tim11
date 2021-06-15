using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{

   
    public class DoctorShiftService
    {
        private IDoctorFileStorage doctorStorage;
        private ICheckupFileStorage checkupStorage;
        public List<DateTime> lisOfFreeDays;
        public NotificationsService notificationsService;




        public DoctorShiftService()
        {
            doctorStorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            notificationsService = new NotificationsService();
            lisOfFreeDays = daysFree();
        }

      public void updatingShift()
        {
            
            List<Doctor> all = doctorStorage.GetAll();
            foreach (Doctor d in all)
            {
                if(d.Shift.LastUpdated.Date.Equals(DateTime.Now.Date))
                {
                    continue;
                }
                else
                {
                    if (d.Shift.ScheduledShifts.Count() != 0)
                    {
                        foreach (ScheduleShift s in d.Shift.ScheduledShifts) //prolazim kroz sve zakazane smene 
                        {
                            if (s.Date.Date.Equals(DateTime.Now.Date)) //ako postoji zakazana za danas 
                            {
                                d.Shift.Type = s.Type; //stavljam tip sadasnje smene na tip zakazane
                                break;
                            }
                        }
                    }                      //ovde menjam smenu klasicno u odnosu na lastUpdate dan
                    int count = countDaysFromLastUpdate(d.Shift.LastUpdated);
                    int numberOfType = (count + Convert.ToInt32(d.Shift.Type)) % 4;
                    setDoctorsShiftType(d, numberOfType);
                    d.Shift.LastUpdated = DateTime.Now;


                }
            }
            doctorStorage.SaveAll(all);
        }

        private static void setDoctorsShiftType(Doctor d, int numberOfType)
        {
            if (numberOfType == 0)
            {
                d.Shift.Type = ShiftType.pause;
            }
            else if (numberOfType == 1)
            {
                d.Shift.Type = ShiftType.first;
            }
            else if (numberOfType == 2)
            {
                d.Shift.Type = ShiftType.second;
            }
            else
            {
                d.Shift.Type = ShiftType.third;
            }
        }

        public String PredictDoctorShift(Doctor doctor, DateTime predict)
        {
            Doctor foundedDoctor = doctorStorage.FindById(doctor.Id);
            int curentShift = Convert.ToInt32(doctor.Shift.Type);
           
            int days = countDays(predict); //nadjem koliko je dana izmedju zakazanih 
            int  numberOfType= 0;
            String typeOfShift = "";

          

                if (foundedDoctor.Shift.ScheduledShifts.Count() != 0)
                {

                    foreach (ScheduleShift s in foundedDoctor.Shift.ScheduledShifts) //provera ako postoji tip smene zakazan za taj dan 
                    {

                        if (predict.Equals(s.Date)) 
                        {
                            numberOfType = Convert.ToInt32(s.Type);   
                            typeOfShift = convertToShift(numberOfType);

                            break;
                        }
                        numberOfType = (days + curentShift) % 4;
                        typeOfShift = convertToShift(numberOfType);
                    }
                }
                else
                {
                    numberOfType = (days + curentShift) % 4;
                    typeOfShift = convertToShift(numberOfType);
                }

                return typeOfShift;
           
        }


        public bool addFreeShift(Doctor doctor, DateTime start, DateTime end)
        {
            Doctor foundedDoctor = doctorStorage.FindById(doctor.Id);
             List<ScheduleShift> shifts = foundedDoctor.Shift.ScheduledShifts; //prethodne doktorove smene koje su zakazane na koje dodajem 
            int freeD = GetWorkingDays(start, end); //izbrojano koliko ima dana izmedju

            if (foundedDoctor.FreeDays < freeD)
            {
                return false;
            }

            foundedDoctor.FreeDays -= freeD; //smanjim broj slobodnih dana
            for ( DateTime countDate = start; countDate <= end; countDate = countDate.AddDays(1))
            {
                ScheduleShift s = new ScheduleShift(countDate, ShiftType.free);
                shifts.Add(s);
            }
            //otkazujem termine ako ima u tom periodu 
            List<Checkup> allCheckups = checkupStorage.GetAll();
            foreach (Checkup c in allCheckups)
            {
                if(c.IdDoctor == doctor.Id)
                {
                    if(c.Date.Date > start.Date.Date && c.Date < end.Date)
                    {
                        checkupStorage.DeleteById(c.Id);
                        Notifications note = new Notifications("obavestenje", "Vas termin u " + c.Date + " je otkazan. Lekar na odmoru.", DateTime.Now, notificationsService.generisiId(), "pacijent", c.IdPatient);
                        notificationsService.createNotificationForPatient(note);
                       
                    }
                }
            }



            foundedDoctor.Shift.ScheduledShifts.Equals(shifts);
          
            doctorStorage.DeleteById(doctor.Id);
            doctorStorage.Save(foundedDoctor);

            return true; //da bih mogla da ispisem koliko mu je jos ostalo 

        }

        public int preostaliDani(Doctor doctor)
        {
           Doctor docr= doctorStorage.FindById(doctor.Id);
            int days = docr.FreeDays;
            return days;
        }

        //nalazi broj radnih  dana koliko ih je izmedju dva datuma
        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            for (var date = from; date < to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }

            return totalDays;
        }

     

        public List<DateTime> daysFree()
        {
            List<DateTime> lisOfDays = new List<DateTime>();
            lisOfDays.Add(Convert.ToDateTime("2021 - 01 - 01T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 02 - 15T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 02 - 16T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 01T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 02T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 03T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 09 - 16T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 11 - 11T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 12 - 25T00: 00:00"));
            return lisOfDays;
        }

        public void changeShift(Doctor doctor, ScheduleShift shift )
        {
            List<Doctor> all = doctorStorage.GetAll();

            Doctor foundedDoctor = doctorStorage.FindById(doctor.Id);
            List<ScheduleShift> newList = new List<ScheduleShift>();
            newList.Add(shift);
            Shift s = new Shift(doctor.Shift.Type, doctor.Shift.LastUpdated, newList);
          // MessageBox.Show("CHANGE SHIFT");
          //  MessageBox.Show(foundedDoctor.Name);
          //  MessageBox.Show(foundedDoctor.Surname);
          //  MessageBox.Show(foundedDoctor.Id.ToString());
            // foundedDoctor.Shift.ScheduledShifts.Add(shift);
            Doctor proba = new Doctor(doctor.Id, doctor.Name, doctor.Surname, doctor.TelephoneNumber, doctor.Jmbg, doctor.Gender, doctor.BirthdayDate, doctor.Adress, doctor.SpecializationType, s, doctor.Vacation);
            doctorStorage.DeleteById(foundedDoctor.Id);
            doctorStorage.Save(proba);
           // doctorStorage.SaveAll(all);
            
        }

        //drugi nacin za change
        public void changeShift2(Doctor doctor, ScheduleShift shift)
        {
            List<Doctor> all = doctorStorage.GetAll();

            DateTime datum = shift.Date;

            foreach (Doctor d in all)
            {
                if(d.Id == doctor.Id)
                {
                    d.Shift.ScheduledShifts.Add(shift);
                    break;
                }
            }
              otkaziTermine(doctor.Id, shift);
              doctorStorage.SaveAll(all);

        }

        //metoda za otkazivanje termina 
        public void otkaziTermine(int idDoctor, ScheduleShift shift) //Datum imam u smeni 
        {
            DateTime start;
            DateTime end;
            if (shift.Type == ShiftType.first)
            {
                start = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 7, 0, 0);
                end = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 14, 0, 0);

            } else if(shift.Type == ShiftType.second)
            {
                start = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 14, 0, 0);
                end = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 21, 0, 0);
            } else if (shift.Type == ShiftType.third )
            {
                start = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 21, 0, 0);
                end = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 23, 59, 0);
            }
            else
            {
                start = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 0, 1, 0);
                end = new DateTime(shift.Date.Year, shift.Date.Month, shift.Date.Day, 23, 59, 0);
            }

            List<Checkup> allCheckups = checkupStorage.GetAll();
            List<Checkup> found = new List<Checkup>();
            foreach(Checkup c in allCheckups)
            {
                if(c.IdDoctor == idDoctor && c.Date.Date == shift.Date.Date)
                {
                    if ( c.Date > end || c.Date < start)   //ako nije u opsegu 
                    {
                        found.Add(c);
                        checkupStorage.DeleteById(c.Id);
                        Notifications note = new Notifications("obavestenje", "Vas termin u " + c.Date + " je otkazan.", DateTime.Now, notificationsService.generisiId(), "pacijent", c.IdPatient);
                        notificationsService.createNotificationForPatient(note);
                      
                    }
                }
            }

         
        }

       
  


        private String convertToShift(int predict)
        {
            String ispisiSmenu;
            if(predict == 0)
            {
                ispisiSmenu = "PAUZA";
            } else if(predict == 1)
            {
                ispisiSmenu = "PRVA";
            } else if(predict == 2)
            {
                ispisiSmenu = "DRUGA";

            }else if(predict == 3)
            {
                ispisiSmenu = "TRECA";
            }
            else
            {
                ispisiSmenu = "NA ODMORU";
            }
            return ispisiSmenu;
        }

        

        public int countDaysFromLastUpdate(DateTime lastUpdate)
        {
            int count;
            DateTime now = DateTime.Now;
            count = ( now.Date - lastUpdate).Days;
            return count;
        }
        public int countDays( DateTime predict)
        {
            int count = 0;
            DateTime now = DateTime.Now;
            count = (predict.Date - now.Date).Days;
            return count;
        }
    }
}
