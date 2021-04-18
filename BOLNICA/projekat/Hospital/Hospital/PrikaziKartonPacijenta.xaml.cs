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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PrikaziKartonPacijenta.xaml
    /// </summary>
    public partial class PrikaziKartonPacijenta : Window
    {

        public ObservableCollection<MedicalRecord> MedicalList
        {
            get;
            set;
        }

        public ObservableCollection<Patient> Pacijenti;
        public Patient patient;
        public int idP;

        public PrikaziKartonPacijenta(ObservableCollection<Patient> list, Patient selectedPatient,int idPac)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = list;
            patient = selectedPatient;
            idP = idPac;
            //MedicalList = loadFileJ(idP);
        }

        /*public ObservableCollection<MedicalRecord> loadFileJ(int id)
        {
            MedicalRecordFileStorage mst = new MedicalRecordFileStorage();
            ObservableCollection<MedicalRecord> mr = new ObservableCollection<MedicalRecord>(mst.GetAll());
            ObservableCollection<MedicalRecord> mrr = new ObservableCollection<MedicalRecord>();
            foreach(MedicalRecord m in mr)
            {
                if(m.patient.patientId == id)
                {
                    ret.Add(m);
                }
            }
            return ret;
        }*/

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}