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
using System.IO;
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PrikaziKartonPacijenta.xaml
    /// </summary>
    public partial class PrikaziKartonPacijenta : Window
    {

        public ObservableCollection<MedicalRecord> MedicalList { get; set; }

        public ObservableCollection<Patient> Pacijenti;
        public Patient patient;
        public int idPatient;

        public PrikaziKartonPacijenta(ObservableCollection<Patient> list, Patient selectedPatient, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = list;
            patient = selectedPatient;
            idPatient = selectedIndex;
            MedicalList = loadMedicalRecordFile();
        }

        public ObservableCollection<MedicalRecord> loadMedicalRecordFile()
        {
            IMedicalRecordFileStorage storageMedicalRecord = new MedicalRecordsFileStorage(@"./../../../../Hospital/files/storageMRecords.json");
            ObservableCollection<MedicalRecord> allMedicalRecords = new ObservableCollection<MedicalRecord>(storageMedicalRecord.GetAll());
            ObservableCollection<MedicalRecord> returnMedicalRecord = new ObservableCollection<MedicalRecord>();
            foreach (MedicalRecord medicalRecord in allMedicalRecords)
            {
                 returnMedicalRecord.Add(medicalRecord);
                
            }
            return returnMedicalRecord;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}