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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DavanjeUputa.xaml
    /// </summary>
    public partial class DavanjeUputa : Window
    {
        public DavanjeUputa()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UputZaAmbulantnoSpecijalistickiPregled uasp = new UputZaAmbulantnoSpecijalistickiPregled();
            uasp.Show();
        }
    }
}