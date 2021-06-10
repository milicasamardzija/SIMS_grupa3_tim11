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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for OBolnici.xaml
    /// </summary>
    public partial class OBolnici : Page
    {
        private PocetnaPacijent parent;
        public OBolnici(PocetnaPacijent p)
        {
            InitializeComponent();
            parent = p;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new KartonPage(parent);

        }
    }
}
