﻿using Hospital.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for ObavestenjaPage.xaml
    /// </summary>
    public partial class ObavestenjaPage : Page
    {

        private List<string> lista;
        private List<string> termini;
        private String danas;
        private String datum;
        
        private int result;

        private PocetnaPacijent parent;
        public ObavestenjaPage(PocetnaPacijent p)
        {
            InitializeComponent();
            parent = p;

            lista = new List<string>();
            lista.Add("Andol 100 14:00");
            lista.Add("Midol 5mg 22:00");
            termini = new List<string>();

            terapija.ItemsSource = lista;

            CheckupFileStorage fs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            ObservableCollection<Checkup> rs = new ObservableCollection<Checkup>(fs.GetAll()); //svi termini
            ObservableCollection<Checkup> ret = new ObservableCollection<Checkup>();

            danas = DateTime.Now.Date.ToString();


            foreach (Checkup appointment in rs)
            {

                if (appointment.IdPatient == p.id )
                {
                    danas = DateTime.Now.Day.ToString();
                    datum = appointment.Date.AddDays(-1).Day.ToString();
             

                    if (danas==datum)
                    {
                        termini.Add("Sutra imate zakazan pregled.Provjerite kalendar.");
                    }
                }
            }

        //    termini.Add("Sutra imate zakazan pregled.Provjerite kalendar.");
            termini.Add(danas);
            obavestenja.ItemsSource = termini;
            
            
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new PacijentPPage(parent);
        }
    }
}
