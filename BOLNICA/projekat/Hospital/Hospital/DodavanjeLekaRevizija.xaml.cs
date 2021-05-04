using Hospital.Controller;
using Hospital.Model;
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
    /// <summary>
    /// Interaction logic for DodavanjeLekaRevizija.xaml
    /// </summary>
    public partial class DodavanjeLekaRevizija : UserControl
    {
        public ObservableCollection<Ingredient> IngredientsBase
        {
            get;
            set;
        }
        public ObservableCollection<Medicine> MedicinesBase
        {
            get;
            set;
        }
        public ObservableCollection<Ingredient> IngredientsMedicine
        {
            get;
            set;
        }
        public ObservableCollection<Medicine> ReplacementMedicine
        {
            get;
            set;
        }
        public Medicine newMedicine;
        public Frame frame;
        private MedicineController controller;

        public DodavanjeLekaRevizija(Frame frameUpravnik)
        {
            InitializeComponent();
            this.DataContext = this;
            frame = frameUpravnik;
            IngredientsBase = loadJasonIngredients();
            MedicinesBase = loadJasonMedicines();
            IngredientsMedicine = new ObservableCollection<Ingredient>();
            ReplacementMedicine = new ObservableCollection<Medicine>();
            newMedicine = new Medicine();
        }

        public ObservableCollection<Ingredient> loadJasonIngredients()
        {
            IngredientsFileStorage storage = new IngredientsFileStorage();
            ObservableCollection<Ingredient> ret = new ObservableCollection<Ingredient>(storage.GetAll());
            return ret;
        }

        public ObservableCollection<Medicine> loadJasonMedicines()
        {
            MedicineFileStorage storage = new MedicineFileStorage();
            ObservableCollection<Medicine> ret = new ObservableCollection<Medicine>(storage.GetAll());
            return ret;
        }

        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            IngredientsMedicine.Add((Ingredient)SastojciBaza.SelectedItem);
            IngredientsBase.Remove((Ingredient)SastojciBaza.SelectedItem);
        }

        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            ReplacementMedicine.Add((Medicine)ZamenskilekoviBaza.SelectedItem);
            MedicinesBase.Remove((Medicine)ZamenskilekoviBaza.SelectedItem);
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            controller.sendMedicineToRevision(newMedicine);
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }
    }
}
