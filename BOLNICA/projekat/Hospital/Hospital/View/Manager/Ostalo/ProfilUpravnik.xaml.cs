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

namespace Hospital.View.Manager.Ostalo
{
    public partial class ProfilUpravnik : UserControl
    {
        public static Boolean isToolTipVisible = true;
        public ProfilUpravnik()
        {
            InitializeComponent();
            Frame.NavigationService.Navigate(new Informacije());
        }

        private void ukljuci(object sender, RoutedEventArgs e)
        {
            isToolTipVisible = true;
        }

        private void iskljuci(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show("Da li ste sigurni da zelite da iskljucite tooltip-ove?", "Tooltips",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    isToolTipVisible = false;
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
    }
}
