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

namespace Hospital
{
    public partial class PrikazZakazanogPremestanja : UserControl
    {
        public ObservableCollection<StaticInventoryMovement> listaInventara = new ObservableCollection<StaticInventoryMovement>();
        public ObservableCollection<StaticInventoryMovement> ListaInvetara
        {
            get { return listaInventara; }
            set { listaInventara = value; }
        }
        public PrikazZakazanogPremestanja()
        {
            InitializeComponent();
            this.DataContext = this;
            listaInventara = loadJason();
        }

        public ObservableCollection<StaticInventoryMovement> loadJason()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            ObservableCollection<StaticInventoryMovement> ret = new ObservableCollection<StaticInventoryMovement>(storage.GetAll());
            return ret;
        }
    }
}
