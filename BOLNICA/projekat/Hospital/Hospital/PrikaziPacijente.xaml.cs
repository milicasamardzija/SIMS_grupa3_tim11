﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PrikaziPacijente.xaml
    /// </summary>
    public partial class PrikaziPacijente : Window
    {

        
        //public ObservableCollection<Patient> listPatient;

        public ObservableCollection<Patient> listPatient
        {
            get;
            set;
        }

        public PrikaziPacijente()
        {
            InitializeComponent();
            this.DataContext = this;
            listPatient = loadJason();
        }


        public ObservableCollection<Patient> loadJason()
        {
            PatientFileStorage pfs = new PatientFileStorage();
            ObservableCollection<Patient> rs = new ObservableCollection<Patient>(pfs.GetAll());
            return rs;
        }


        private void izmeniNalogPacijenta(object sender, RoutedEventArgs e)
        {

            IzmeniNalogPacijenta izmenaNaloga = new IzmeniNalogPacijenta();
            izmenaNaloga.ShowDialog();
        }

        private void izbrisiNalogPacijenta(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
