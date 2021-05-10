﻿using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for SacuvajDatum.xaml
    /// </summary>
    public partial class SacuvajDatum : Window
    {
        public List<Doctor> listDoctors { get; set; }
        public Patient patient;
        public int idRoom;
        public DateTime chosenDate;
       
        public CheckupController controller = new CheckupController();

        public SacuvajDatum(DateTime date, int idR, Patient selectedPatient)
        {
            InitializeComponent();
            this.DataContext = this;
            patient = selectedPatient;
            idRoom = idR;
            chosenDate = date;
            listDoctors = findAvailableDoctors(date);

        }

        public List<Doctor> findAvailableDoctors(DateTime date)
        {
            return controller.availableDoctors(date);
        }

        private void CreateCheckup(object sender, RoutedEventArgs e)
        {
            Doctor d = (Doctor)doctors.SelectedItem;
            int idDoctor = d.DoctorId;
            controller.createCheckup(new Checkup(0, idDoctor, patient.PatientId, chosenDate, idRoom, 0));
            this.Close();
        }

        private void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
