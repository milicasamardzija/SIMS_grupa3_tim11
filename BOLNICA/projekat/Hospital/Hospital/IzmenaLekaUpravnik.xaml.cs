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
   
    public partial class IzmenaLekaUpravnik : UserControl
    {
        private Medicine medicine = new Medicine();
        public Medicine Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }
    
        private ObservableCollection<Ingredient> ingredientsBase = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> IngredientsBase
        {
            get { return ingredientsBase; }
            set { ingredientsBase = value;}
        }
        private ObservableCollection<Medicine> medicinesBase = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> MedicinesBase
        {
            get { return medicinesBase; }
            set { medicinesBase = value; }
        }
        private ObservableCollection<Ingredient> ingredientsMedicine = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> IngredientsMedicine
        {
            get { return ingredientsMedicine; }
            set { ingredientsMedicine = value; }
        }
        private ObservableCollection<Medicine> replacementMedicine = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> ReplacementMedicine
        {
            get { return replacementMedicine; }
            set { replacementMedicine = value; }
        }

        private Frame frame = new Frame();
        private ObservableCollection<Medicine> allMedicines = new ObservableCollection<Medicine>();
        private MedicineFileStorage storage = new MedicineFileStorage();
        private List<int> medicineIds = new List<int>();
        private List<int> ingredientsIds = new List<int>();

        public IzmenaLekaUpravnik(Medicine selectedMedicine,Frame managerFrame,ObservableCollection<Medicine> medicines)
        {
            InitializeComponent();
            this.DataContext = this;
            medicine = selectedMedicine;
            ingredientsBase = loadJasonIngredients();
            medicinesBase = loadJasonMedicines();
            ingredientsMedicine = loadJsonMedicineIngredients();
            replacementMedicine = loadJsonReplacementMedicines();
            frame = managerFrame;
            allMedicines = medicines;
        }
        public ObservableCollection<Medicine> loadJsonReplacementMedicines()
        {
            MedicineFileStorage storage = new MedicineFileStorage();
            ObservableCollection<Medicine> ret = new ObservableCollection<Medicine>();
            if (medicine != null) {
                foreach (int id in medicine.IdsMedicines)
                {
                    foreach (Medicine medicine in storage.GetAll())
                    {
                        if (medicine.IdMedicine == id)
                        {
                            ret.Add(medicine);
                            break;
                        }
                    }
                }
            }
            return ret;
        }
        public ObservableCollection<Ingredient> loadJsonMedicineIngredients()
        {
            IngredientsFileStorage storage = new IngredientsFileStorage();
            ObservableCollection<Ingredient> ret = new ObservableCollection<Ingredient>();
            if (medicine != null)
            {
                foreach (int id in medicine.IdsIngredients)
                {
                    foreach (Ingredient ingredient in storage.GetAll())
                    {
                        if (ingredient.IdIngredient == id)
                        {
                            ret.Add(ingredient);
                            break;
                        }
                    }
                }
            }
            return ret;
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

        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            ingredientsMedicine.Add((Ingredient)SastojciBaza.SelectedItem);
            ingredientsBase.Remove((Ingredient)SastojciBaza.SelectedItem);
        }

        private void isbrisiSastojak(object sender, RoutedEventArgs e)
        {
            ingredientsBase.Add((Ingredient)SastojciLek.SelectedItem);
            ingredientsMedicine.Remove((Ingredient)SastojciLek.SelectedItem); 
        }

        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            replacementMedicine.Add((Medicine)ZamenskilekoviBaza.SelectedItem);
            medicinesBase.Remove((Medicine)ZamenskilekoviBaza.SelectedItem);
        }

        private void izbrisiZamenskiLek(object sender, RoutedEventArgs e)
        {
            medicinesBase.Add((Medicine)ZamenskiLekoviLek.SelectedItem);
            replacementMedicine.Remove((Medicine)ZamenskiLekoviLek.SelectedItem);
        }
        public void convert()
        {
            foreach (Medicine medicine in ReplacementMedicine)
            {
                medicineIds.Add(medicine.IdMedicine);
            }
            foreach (Ingredient ingredient in IngredientsMedicine)
            {
                ingredientsIds.Add(ingredient.IdIngredient);
            }
        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            NazivTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TipTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            GramazaTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            convert();
            medicine.IdsMedicines = medicineIds;
            medicine.IdsIngredients = ingredientsIds;

            storage.SaveAll(allMedicines.ToList());
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }
    }
}
