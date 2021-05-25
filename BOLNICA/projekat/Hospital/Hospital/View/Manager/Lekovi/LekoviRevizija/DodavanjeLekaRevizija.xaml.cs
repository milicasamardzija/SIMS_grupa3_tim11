using Hospital.Controller;
using Hospital.FileStorage.Interfaces;
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

        private Frame frame;
        private MedicineController controller;
        private DoctorFileStorage storage;
        private List<int> medicineIds;
        private List<int> ingredientsIds;

        public DodavanjeLekaRevizija(Frame frameUpravnik)
        {
            InitializeComponent();
            this.DataContext = this;
            frame = frameUpravnik;
            IngredientsBase = loadJasonIngredients();
            MedicinesBase = loadJasonMedicines();
            IngredientsMedicine = new ObservableCollection<Ingredient>();
            ReplacementMedicine = new ObservableCollection<Medicine>();
            controller = new MedicineController();
            medicineIds = new List<int>();
            ingredientsIds = new List<int>();
            storage = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            dodajSpecijalizacije();
        }

        public ObservableCollection<Ingredient> loadJasonIngredients()
        {
            IngredientsIFileStorage storage = new IngredientsFileStorage("./../../../../Hospital/files/storageIngredients.json");
            ObservableCollection<Ingredient> ret = new ObservableCollection<Ingredient>(storage.GetAll());
            return ret;
        }

        public ObservableCollection<Medicine> loadJasonMedicines()
        {
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> ret = new ObservableCollection<Medicine>();
                foreach (Medicine medicine in storage.GetAll())
                {
                    if (medicine.Approved)
                    {
                        ret.Add(medicine);
                    }
                }
            return ret;
        }

        public int generisiId()
        {
            int ret = 0;

            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            List<Medicine> all = storage.GetAll();

            foreach (Medicine mediicneBig in all)
            {
                foreach (Medicine medicine in all)
                {
                    if (ret == medicine.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            IngredientsMedicine.Add((Ingredient)SastojciBaza.SelectedItem);
            IngredientsBase.Remove((Ingredient)SastojciBaza.SelectedItem);
        }

        public void convert()
        {
            foreach (Medicine medicine in ReplacementMedicine)
            {
                medicineIds.Add(medicine.Id);
            }
            foreach (Ingredient ingredient in IngredientsMedicine)
            {
                ingredientsIds.Add(ingredient.Id);
            }
        }
        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            ReplacementMedicine.Add((Medicine)ZamenskilekoviBaza.SelectedItem);
            MedicinesBase.Remove((Medicine)ZamenskilekoviBaza.SelectedItem);
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            convert();
            ComboBoxItem item = (ComboBoxItem)DoktoriIsfiltrirani.SelectedItem;
            controller.sendMedicineToRevision(new Medicine(generisiId(), NazivTxt.Text, Convert.ToDouble(GramazaTxt.Text), TipTxt.Text, ingredientsIds, medicineIds, false), Convert.ToInt32(item.Tag));
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        public void dodajSpecijalizacije()
        {

            SpecijalizacijaComboBox.ItemsSource = Enum.GetValues(typeof(SpecializationType));  

        }

        public List<Doctor> doktoriPoSpecijalizaciji()
        {
            List<Doctor> filtratedDoctors = new List<Doctor>();
            foreach (Doctor doctor in storage.GetAll())
            {  
                if(doctor.SpecializationType == (SpecializationType)SpecijalizacijaComboBox.SelectedItem)
                {
                    filtratedDoctors.Add(doctor);
                }
            }
            
            return filtratedDoctors;
        }

        private void getDoctors(object sender, SelectionChangedEventArgs e)
        {
            DoktoriIsfiltrirani.Items.Clear();
            List<Doctor> doctors = doktoriPoSpecijalizaciji();
            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = doctor.Name + "  " + doctor.Surname;
                item.Tag = doctor.Id;
                DoktoriIsfiltrirani.Items.Add(item);
            }

        }
    }
}
