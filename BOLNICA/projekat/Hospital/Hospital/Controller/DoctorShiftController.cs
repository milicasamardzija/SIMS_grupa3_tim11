using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
using System;

namespace Hospital.Controller
{
    public class DoctorShiftController
    {

        private DoctorShiftService shiftService;

        public DoctorShiftController()
        {
            shiftService = new DoctorShiftService();


        }

        public void updateShift()
        {
            shiftService.updatingShift();
        }
        public void changeShift(DoctorDTO chocenDoctor, ScheduleShiftDTO shift)
        {
            Doctor doctor = new Doctor(chocenDoctor.Id, chocenDoctor.Name, chocenDoctor.Surname, chocenDoctor.TelephoneNumber, chocenDoctor.Jmbg, chocenDoctor.Gender, chocenDoctor.BirthdayDate, chocenDoctor.Adress, chocenDoctor.Type, chocenDoctor.Shift, chocenDoctor.Vacation);
            ScheduleShift newShift = new ScheduleShift(shift.Type, shift.Date);
            shiftService.changeShift(doctor, newShift);

        }

        public void changeShift2(DoctorDTO chocenDoctor, ScheduleShiftDTO shift)
        {
            Doctor doctor = new Doctor(chocenDoctor.Id, chocenDoctor.Name, chocenDoctor.Surname, chocenDoctor.TelephoneNumber, chocenDoctor.Jmbg, chocenDoctor.Gender, chocenDoctor.BirthdayDate, chocenDoctor.Adress, chocenDoctor.Type, chocenDoctor.Shift, chocenDoctor.Vacation);
            ScheduleShift newShift = new ScheduleShift(shift.Type, shift.Date);
            shiftService.changeShift(doctor, newShift);

        }
        public String PredictDoctorShift(DoctorDTO chosenDoctor, DateTime date)
        {
            Doctor doctor = new Doctor(chosenDoctor.Id, chosenDoctor.Name, chosenDoctor.Surname, chosenDoctor.TelephoneNumber, chosenDoctor.Jmbg, chosenDoctor.Gender, chosenDoctor.BirthdayDate, chosenDoctor.Adress, chosenDoctor.Type, chosenDoctor.Shift, chosenDoctor.Vacation);
            return shiftService.PredictDoctorShift(doctor, date);
        }

        public bool addFreeShift(DoctorDTO doctor, DateTime start, DateTime end)
        {
            Doctor forVacation = new Doctor(doctor.Id, doctor.Name, doctor.Surname, doctor.TelephoneNumber, doctor.Jmbg, doctor.Gender, doctor.BirthdayDate, doctor.Adress
                , doctor.Type, doctor.Shift, doctor.Vacation);
           return  shiftService.addFreeShift(forVacation, start, end);
        }


        //za ispis koliko je jos slobodnih dana ostalo
        public int preostaliDani (DoctorDTO doctor)
        {
            Doctor forDays = new Doctor(doctor.Id, doctor.Name, doctor.Surname, doctor.TelephoneNumber, doctor.Jmbg, doctor.Gender, doctor.BirthdayDate, doctor.Adress
               , doctor.Type, doctor.Shift, doctor.Vacation);
            return shiftService.preostaliDani(forDays);
        }
    }
}
