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
    /// Interaction logic for Pacijent.xaml
    /// </summary>
    public partial class Pacijent : Window
    {
        public Pacijent()
        {
            InitializeComponent();
        }

       

        private void add_btn(object sender, RoutedEventArgs e)
        {
            DodajTermin dd = new DodajTermin();
            dd.Show();
        }

        private void update_btn(object sender, RoutedEventArgs e)
        {
            IzmeniTermin iz = new IzmeniTermin();
            iz.Show();
        }

        private void delete_btn(object sender, RoutedEventArgs e)
        {
            ObrisiTermin ot = new ObrisiTermin();
            ot.Show();
        }
    }
}
