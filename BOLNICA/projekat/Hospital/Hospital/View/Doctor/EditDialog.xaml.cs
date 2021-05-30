﻿using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Hospital.Model;
using Newtonsoft.Json;
using System.IO;
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {
        public List<Checkup> listCheckup;
        public Checkup checkup;
        public int indexCheckup;
        public int idD;

        public EditDialog(List<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            indexCheckup = selectedIndex;

            datePick.SelectedDate = Convert.ToDateTime(selectedCheckup.Date);
            durationText.SelectedText = Convert.ToString(selectedCheckup.Duration);
            comboBox.SelectedIndex = (int)selectedCheckup.Type;
            patientBox.SelectedText = Convert.ToString(selectedCheckup.IdPatient);
            idRoom.SelectedText = Convert.ToString(selectedCheckup.IdRoom);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public int generisiID()
        {
            int returnCheckup = 0;
            ICheckFileStorage storage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storage.GetAll();
            foreach (Checkup checkups in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (returnCheckup == checkup.Id)
                    {
                        ++returnCheckup;
                        break;
                    }
                }
            }
            return returnCheckup;
        }

        public int getDoctorFromFile() 
        {
            int returnDoctor = 0;
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json")); 

            foreach (Doctor doctor in doctors)  
            {
                 if (doctor.Id == idD) 
                 {
                    returnDoctor = idD;
                break;
                }
            }

            return returnDoctor;
        }

        public void componentsEditDialog()
        {
            checkup.Date = datePick.DisplayDate;
            checkup.Duration = Convert.ToDouble(durationText.Text);
            checkup.Type = (CheckupType)comboBox.SelectedIndex;
            checkup.IdPatient = Convert.ToInt16(patientBox.Text);
            checkup.IdRoom = Convert.ToInt16(idRoom.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ICheckFileStorage st = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            componentsEditDialog();

            listCheckup[indexCheckup] = new Checkup(generisiID(), getDoctorFromFile(), Convert.ToInt16(checkup.IdPatient), Convert.ToDateTime(checkup.Date),
                Convert.ToInt16(checkup.IdRoom), (CheckupType)comboBox.SelectedIndex);

            st.DeleteById(Convert.ToInt16(durationText.Text));
            st.Save(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
