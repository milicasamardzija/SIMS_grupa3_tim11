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
        public List<DateTime> lisOfFreeDays;


        public DoctorShiftService()
        {
            doctorStorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            lisOfFreeDays = daysFree();
        }

      public void updatingShift()
        {
            List<Doctor> all = doctorStorage.GetAll();
            int count = 0;

            foreach(Doctor d in all)
            {
                if(d.Shift.LastUpdated.Equals(DateTime.Now))
                {
                    continue;
                }
                else
                {
                    if(d.Shift.ScheduledShifts.Count() != 0)
                    {
                        foreach(ScheduleShift s in d.Shift.ScheduledShifts)
                        {
                            if(s.Date.Equals(DateTime.Now) && s.Change == false)
                            {
                                d.Shift.Type.Equals( s.Type); //stavljam tip sadasnje smene na tip zakazane, control ne diram, pa to ovde preskacem 
                               
                            }
                            else if(s.Date.Equals(DateTime.Now) && s.Change == true)
                            {
                                d.Shift.Type.Equals(s.Type);
                                d.Shift.ControlType.Equals(s.Type); //ako je rolanje obe stavljam na taj navedeni tip

                            }
                            //ako nije nista od toga izlazim

                        }
                    } else
                    {
                        //ovde menjam smenu klasicno u odnosu na lastUpdate dan
                        count = countDaysFromLastUpdate(d.Shift.LastUpdated);
                        int numberOfType = (count + Convert.ToInt32(d.Shift.Type)) % 4;
                        d.Shift.Type.Equals(numberOfType);
                        d.Shift.ControlType.Equals(numberOfType);

                    }
                }
            }
            doctorStorage.SaveAll(all);
        }

        public String PredictDoctorShift(Doctor doctor, DateTime predict)
        {
            Doctor foundedDoctor = doctorStorage.FindById(doctor.Id);
            int curentShift = Convert.ToInt32(doctor.Shift.Type);
            int controlShift = Convert.ToInt32(doctor.Shift.ControlType);
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


        public int addFreeShift(Doctor doctor, DateTime start, DateTime end)
        {
            Doctor foundedDoctor = doctorStorage.FindById(doctor.Id);
           
            List<ScheduleShift> shifts = foundedDoctor.Shift.ScheduledShifts; //prethodne doktorove smene koje su zakazane na koje dodajem 
           for( DateTime countDate= start.Date; countDate<= end; countDate=countDate.AddDays(1))
            {
                ScheduleShift s = new ScheduleShift(countDate, ShiftType.free, false);
                shifts.Add(s);
                
             
            } 

            foundedDoctor.Shift.ScheduledShifts.Equals(shifts);
            int freeD = GetWorkingDays(start, end);
            
            int alldays = foundedDoctor.Vacation.FreeDays - freeD;
            foundedDoctor.Vacation.FreeDays.Equals(alldays);
            doctorStorage.DeleteById(doctor.Id);
            doctorStorage.Save(foundedDoctor);

            return alldays; //da bih mogla da ispisem koliko mu je jos ostalo 

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

        //nedovrseno
        public void countFreeDays(Doctor doctor, DateTime start, DateTime end)
        {
            Doctor doctorWithRequst = doctorStorage.FindById(doctor.Id);
            List<DateTime> dates = new List<DateTime>();
            int numberOfDays = (end.Date - start.Date).Days; //number of days beetween
            


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
            Shift s = new Shift(doctor.Shift.Type, doctor.Shift.ControlType, doctor.Shift.LastUpdated, newList);
          // MessageBox.Show("CHANGE SHIFT");
          //  MessageBox.Show(foundedDoctor.Name);
          //  MessageBox.Show(foundedDoctor.Surname);
          //  MessageBox.Show(foundedDoctor.Id.ToString());
            // foundedDoctor.Shift.ScheduledShifts.Add(shift);
            Doctor proba = new Doctor(doctor.Id, doctor.Name, doctor.Surname, doctor.TelephoneNumber, doctor.Jmbg, doctor.Gender, doctor.BirthdayDate, doctor.Adress, doctor.SpecializationType, s, doctor.Vacation);
            doctorStorage.Delete(foundedDoctor);
            doctorStorage.Save(proba);
           // doctorStorage.SaveAll(all);
            
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
            int count = 0;
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
