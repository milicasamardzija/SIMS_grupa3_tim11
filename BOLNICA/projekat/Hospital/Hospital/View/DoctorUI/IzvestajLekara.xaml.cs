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
    /// Interaction logic for IzvestajLekara.xaml
    /// </summary>
    public partial class IzvestajLekara : Window
    {
        public IzvestajLekara()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrikaziIzvestajLekara showReport = new PrikaziIzvestajLekara();
            showReport.Show();
            this.Close();

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            datePicker1.BlackoutDates.Add(kalendar);
            datePicker2.BlackoutDates.Add(kalendar);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}