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
        public ObservableCollection<IngredientDTO> IngredientsBase { get; set; }
        public ObservableCollection<MedicineDTO> MedicinesBase { get; set; }
        public ObservableCollection<IngredientDTO> IngredientsMedicine { get; set; }
        public ObservableCollection<MedicineDTO> ReplacementMedicine { get; set; }

        private Frame frame;
        private DoctorFileStorage storage;
        private List<int> medicineIds;
        private List<int> ingredientsIds;
        private MedicineController medicineController;
        private IngredientController ingredientController;
        private Point? _startPoint = new Point();

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
            IngredientsMedicine.Add((IngredientDTO) SastojciBaza.SelectedItem);
            IngredientsBase.Remove((IngredientDTO) SastojciBaza.SelectedItem);
        }

        private void dodajZamenskiLek(object sender, RoutedEventArgs e)
        {
            ReplacementMedicine.Add((MedicineDTO) ZamenskilekoviBaza.SelectedItem);
            MedicinesBase.Remove((MedicineDTO) ZamenskilekoviBaza.SelectedItem);
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            medicineIds = medicineController.convertReplacementMedicinesIntoIds(ReplacementMedicine.ToList());
            ingredientsIds = ingredientController.convertReplacementMedicinesIntoIds(IngredientsMedicine.ToList());
            medicineController.sendMedicineToRevision(
                new MedicineDTO(-1, NazivTxt.Text, Convert.ToDouble(GramazaTxt.Text), TipTxt.Text, ingredientsIds,
                    medicineIds, false), Convert.ToInt32(
                    ((ComboBoxItem) DoktoriIsfiltrirani.SelectedItem).Tag));
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
                if (doctor.SpecializationType == (SpecializationType) SpecijalizacijaComboBox.SelectedItem)
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

        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T) current;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }

        private void SastojciBaza_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        private void SastojciBaza_MouseMove(object sender, MouseEventArgs e)
        {
            // No drag operation
            if (_startPoint == null)
                return;

            var dg = sender as DataGrid;
            if (dg == null) return;
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint.Value - mousePos;
            // test for the minimum displacement to begin the drag
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                // Get the dragged DataGridRow
                var DataGridRow =
                    FindAnchestor<DataGridRow>((DependencyObject) e.OriginalSource);

                if (DataGridRow == null)
                    return;
                // Find the data behind the DataGridRow
                var dataTodrop = (IngredientDTO) dg.ItemContainerGenerator.ItemFromContainer(DataGridRow);

                if (dataTodrop == null) return;

                // Initialize the drag & drop operation
                var dataObj = new DataObject(dataTodrop);
                dataObj.SetData("DragSource", sender);
                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Copy);
                _startPoint = null;
            }
        }

        private void SastojciLek_Drop(object sender, DragEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            var dgSrc = e.Data.GetData("DragSource") as DataGrid;
            var data = e.Data.GetData(typeof(IngredientDTO));
            if (dgSrc == null || data == null) return;
            IngredientsBase.Remove((IngredientDTO) data);
            IngredientsMedicine.Add((IngredientDTO) data);
        }
    }
}
