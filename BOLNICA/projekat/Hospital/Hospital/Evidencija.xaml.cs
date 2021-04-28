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
    /// Interaction logic for Evidencija.xaml
    /// </summary>
    public partial class Evidencija : Window
    {
        public Evidencija()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzmenaLeka il = new IzmenaLeka();
            il.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ZamenaLekova zl = new ZamenaLekova();
            zl.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            PotroseniMaterijal potr = new PotroseniMaterijal();
            potr.Show();
        }
    }
}
