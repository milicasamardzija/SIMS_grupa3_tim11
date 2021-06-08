using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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
using System.Windows.Shapes;

namespace Hospital.Sekretar
{
    public partial class Alergeni : Window
    {
    
       
        public MedicalRecordDTO record;
        public PatientDTO patient;
        public ObservableCollection<PatientDTO> listPatient;
        public ObservableCollection<MedicalRecordDTO> listRecord;
        public MedicalRecordController controller;
        int index;
        private Point? _startPoint = new Point();
        public int id;

        public ObservableCollection<AlergensDTO> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<AlergensDTO> listAlergens
        {
            get;
            set;
        }
        public Alergeni(ObservableCollection<PatientDTO> list, PatientDTO selectedPatient, int sel)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new MedicalRecordController();
            id = selectedPatient.Id;
          //  MessageBoxResult res= MessageBox.Show(Convert.ToString(id));
            record = controller.findRecordById(id);
           // MessageBoxResult res1 = MessageBox.Show(Convert.ToString(record.Name));
            //MessageBoxResult res2 = MessageBox.Show(Convert.ToString(record.MedicalRecordId));

            listAllAlergens = loadJasonAllAlergens();
            listAlergens = loadPatientAlergens(id);

            listPatient = list;

            foreach (PatientDTO p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

            index = sel;

        }

        public ObservableCollection<AlergensDTO> loadJasonAllAlergens()
        {
            return controller.getAllAlergens();
        }

        public ObservableCollection<AlergensDTO> loadPatientAlergens(int idPatient)
        {
            return controller.loadPatientAlergens(idPatient);
        }

        private void AddAlergens(object sender, RoutedEventArgs e)
        { if (svi.SelectedItem != null)
            {
                listAlergens.Add((AlergensDTO)svi.SelectedItem);
                listAllAlergens.Remove((AlergensDTO)svi.SelectedItem);
            } else {
                MessageBoxResult result = MessageBox.Show("Niste odabrali alergen!");
            }
        }

      

        private void RemoveAlergen(object sender, RoutedEventArgs e)
        {
            listAlergens.Remove((AlergensDTO)selected.SelectedItem);
        }

        private void saveAlergens(object sender, RoutedEventArgs e)
        {
            MedicalRecordDTO promeniM = controller.findRecordById(id);
            promeniM.Alergens = listAlergens;
            controller.deleteRecordById(id);
            controller.saveMedicalRecord(promeniM);
            this.Close();
        }


        private static T FindAnchestor<T>(DependencyObject current)
           where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void svi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        private void svi_MouseMove(object sender, MouseEventArgs e)
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
                    FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (DataGridRow == null)
                    return;
                // Find the data behind the DataGridRow
                var dataTodrop = (AlergensDTO)dg.ItemContainerGenerator.ItemFromContainer(DataGridRow);

                if (dataTodrop == null) return;

                // Initialize the drag & drop operation
                var dataObj = new DataObject(dataTodrop);
                dataObj.SetData("DragSource", sender);
                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Copy);
                _startPoint = null;
            }
        }

        private void selected_Drop(object sender, DragEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null) return;
            var dgSrc = e.Data.GetData("DragSource") as DataGrid;
            var data = e.Data.GetData(typeof(AlergensDTO));
            if (dgSrc == null || data == null) return;
            listAllAlergens.Remove((AlergensDTO)data);
            listAlergens.Add((AlergensDTO)data);
        }
    }
}
