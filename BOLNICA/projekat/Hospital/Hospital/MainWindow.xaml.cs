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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Prijava prijava = new Prijava(new BlogGlavni());
            frame.Navigate(prijava);
            
        }

        private void prijava(object sender, RoutedEventArgs e)
        {
            Prijava p = new Prijava(new BlogGlavni());
            frame.Navigate(p);


                foreach (Patient patient in patients)
                {
                    if (patient.username.Equals(ime.Text) && patient.password.Equals(lozinka.Password)) //ako su sifra i korisnicko ime nadjeni u fajlu
                    {
                        id = patient.PatientId; //preuzimamo id pacijenta koji dalje prosledjujemo prozoru koji se prvi otvara, pa dalje ostalim prozorima da bismo uvek prikazivali podatke na osnovu ovog id-ja(odnosno bas sa korisnika koji je ulogovan)
                        WindowPacijent p = new WindowPacijent(id); //otvara se prozor i prosledjuje id
                        p.Show();
                        this.Close(); 
                        return; //da ne bi trazio u drugim fajlovima
                    }
                }
            }
            else if (uloga.SelectedIndex == 1) //lekar
            {
                DoctorFileStorage df = new DoctorFileStorage();
                List<Doctor> doctors = df.GetAll();

                foreach (Doctor doctor in doctors)
                {
                    if (doctor.username.Equals(ime.Text) && doctor.password.Equals(lozinka.Password))
                    {
                        id = doctor.doctorId;
                        Pregled d = new Pregled(id); 
                        d.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else if (uloga.SelectedIndex == 2) //sekretar
            {
                SecretaryFileStorage sf = new SecretaryFileStorage();
                List<Secretary> secretaries = sf.GetAll();

                foreach (Secretary secretary in secretaries)
                {
                    if (secretary.username.Equals(ime.Text) && secretary.password.Equals(lozinka.Password))
                    {
                        id = secretary.secretaryId;
                        Nalozi s = new Nalozi();
                        s.Show();
                        this.Close();
                        return;
                    }
                }
            }
            else if (uloga.SelectedIndex == 3) //upravnik
            {
                ManagerFileStorage mf = new ManagerFileStorage();
                List<Manager> managers = mf.GetAll();

        }

        private void blog(object sender, RoutedEventArgs e)
        {
            BlogGlavni b = new BlogGlavni();
            frame.Navigate(b);

        }

        
    }
}