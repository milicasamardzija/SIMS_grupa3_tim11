﻿using Hospital.Controller;
using Hospital.DTO;
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

namespace Hospital.View.Secretary.CRUDPatient.RegistredPatient
{
    /// <summary>
    /// Interaction logic for BlokiraniPacijenti.xaml
    /// </summary>
    public partial class BlokiraniPacijenti : Window
    {
        public ObservableCollection<PatientDTO> listBlocked { get; set; }
        public PatientController patientController = new PatientController();
        
        public BlokiraniPacijenti()
        {
            InitializeComponent();
            this.DataContext = this;
            listBlocked = loadBlockedPatient();
        }

        public ObservableCollection<PatientDTO> loadBlockedPatient()
        {
            return patientController.loadBlockedPatients();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OdblokirajBtn(object sender, RoutedEventArgs e)
        {
            if ((PatientDTO)PrikazPacijenata.SelectedItem != null)
            {
                patientController.odblokirajPacijenta((PatientDTO)PrikazPacijenata.SelectedItem);
                OdblokirajPacijenta odblokiranNote = new OdblokirajPacijenta(listBlocked, PrikazPacijenata.SelectedIndex);
                odblokiranNote.Show();

            }
        }
        private void DeclineBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
