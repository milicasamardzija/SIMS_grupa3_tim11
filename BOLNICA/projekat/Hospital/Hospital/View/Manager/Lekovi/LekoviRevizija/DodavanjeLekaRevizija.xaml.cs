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
using Hospital.DTO;

namespace Hospital
{
    public partial class DodavanjeLekaRevizija : UserControl
    {
        public ObservableCollection<IngredientDTO> IngredientsBase
        {
            get;
            set;
        }
        public ObservableCollection<MedicineDTO> MedicinesBase
        {
            get;
            set;
        }
        public ObservableCollection<IngredientDTO> IngredientsMedicine
        {
            get;
            set;
        }
        public ObservableCollection<MedicineDTO> ReplacementMedicine
        {
            get;
            set;
        }

        private Frame frame;
        private DoctorFileStorage storage;
        private List<int> medicineIds;
        private List<int> ingredientsIds;
        private MedicineController medicineController;
        private IngredientController ingredientController;

        public DodavanjeLekaRevizija(Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.medicineController = new MedicineController();
            this.ingredientController = new IngredientController();
            IngredientsBase = new ObservableCollection<IngredientDTO>(ingredientController.getAll());
            MedicinesBase = new ObservableCollection<MedicineDTO>(medicineController.getAll());
            IngredientsMedicine = new ObservableCollection<IngredientDTO>();
            ReplacementMedicine = new ObservableCollection<MedicineDTO>();
            medicineIds = new List<int>();
            ingredientsIds = new List<int>();
            dodajSpecijalizacije();
        }
        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            IngredientsMedicine.Add((IngredientDTO)SastojciBaza.SelectedItem);
            IngredientsBase.Remove((IngredientDTO)SastojciBaza.SelectedItem);
        }

        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            ReplacementMedicine.Add((MedicineDTO)ZamenskilekoviBaza.SelectedItem);
            MedicinesBase.Remove((MedicineDTO)ZamenskilekoviBaza.SelectedItem);
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
          medicineIds = medicineController.convertReplacementMedicinesIntoIds(ReplacementMedicine.ToList());
          ingredientsIds = ingredientController.convertReplacementMedicinesIntoIds(IngredientsMedicine.ToList());
            medicineController.sendMedicineToRevision(new MedicineDTO(-1, NazivTxt.Text, Convert.ToDouble(GramazaTxt.Text), TipTxt.Text, ingredientsIds, medicineIds, false), Convert.ToInt32(
                ((ComboBoxItem)DoktoriIsfiltrirani.SelectedItem).Tag));
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
            DoctorFileStorage storage = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
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
