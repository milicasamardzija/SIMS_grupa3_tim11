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
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    public partial class IzmenaLekaUpravnik : UserControl
    {
        private MedicineDTO medicine = new MedicineDTO();
        public MedicineDTO Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }
    
        private ObservableCollection<IngredientDTO> ingredientsBase = new ObservableCollection<IngredientDTO>();
        public ObservableCollection<IngredientDTO> IngredientsBase
        {
            get { return ingredientsBase; }
            set { ingredientsBase = value;}
        }
        private ObservableCollection<MedicineDTO> medicinesBase = new ObservableCollection<MedicineDTO>();
        public ObservableCollection<MedicineDTO> MedicinesBase
        {
            get { return medicinesBase; }
            set { medicinesBase = value; }
        }
        private ObservableCollection<IngredientDTO> ingredientsMedicine = new ObservableCollection<IngredientDTO>();
        public ObservableCollection<IngredientDTO> IngredientsMedicine
        {
            get { return ingredientsMedicine; }
            set { ingredientsMedicine = value; }
        }
        private ObservableCollection<MedicineDTO> replacementMedicine = new ObservableCollection<MedicineDTO>();
        public ObservableCollection<MedicineDTO> ReplacementMedicine
        {
            get { return replacementMedicine; }
            set { replacementMedicine = value; }
        }

        private Frame frame;
        private ObservableCollection<MedicineDTO> allMedicines;
        private MedicineController medicineController;
        private IngredientController ingredientController;

        public IzmenaLekaUpravnik(MedicineDTO medicine,Frame frame,ObservableCollection<MedicineDTO> medicines)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.allMedicines = medicines;
            this.medicine = medicine;
            this.medicineController = new MedicineController();
            this.ingredientController = new IngredientController();
            this.ingredientsBase = new ObservableCollection<IngredientDTO>(ingredientController.getAll());
            this.medicinesBase = new ObservableCollection<MedicineDTO>(medicineController.loadApprovedMedicines());
            this.ingredientsMedicine = new ObservableCollection<IngredientDTO>(ingredientController.loadMedicineIngredients(medicine));
            this.replacementMedicine = new ObservableCollection<MedicineDTO>(medicineController.loadReplacementMedicines(medicine));
        }

        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            ingredientsMedicine.Add((IngredientDTO)SastojciBaza.SelectedItem);
            ingredientsBase.Remove((IngredientDTO)SastojciBaza.SelectedItem);
        }

        private void isbrisiSastojak(object sender, RoutedEventArgs e)
        {
            ingredientsBase.Add((IngredientDTO)SastojciLek.SelectedItem);
            ingredientsMedicine.Remove((IngredientDTO)SastojciLek.SelectedItem); 
        }

        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            replacementMedicine.Add((MedicineDTO)ZamenskilekoviBaza.SelectedItem);
            medicinesBase.Remove((MedicineDTO)ZamenskilekoviBaza.SelectedItem);
        }

        private void izbrisiZamenskiLek(object sender, RoutedEventArgs e)
        {
            medicinesBase.Add((MedicineDTO)ZamenskiLekoviLek.SelectedItem);
            replacementMedicine.Remove((MedicineDTO)ZamenskiLekoviLek.SelectedItem);
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            NazivTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TipTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            GramazaTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            medicine.IdsMedicines = medicineController.convertReplacementMedicinesIntoIds(ReplacementMedicine.ToList());
            medicine.IdsIngredients = ingredientController.convertReplacementMedicinesIntoIds(IngredientsMedicine.ToList());

            medicineController.update(medicine);
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }
    }
}
