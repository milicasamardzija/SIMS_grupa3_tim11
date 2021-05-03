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
        public Window window;
        public MedicalRecord newRecord;
        public Patient newPatient;
        public ObservableCollection<Alergens> newAlergens;
        public Alergens newAlergen;

        public ObservableCollection<Alergens> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<Alergens> listAlergens
        {
            get;
            set;
        }
        public Alergeni(Window w)
        {
            InitializeComponent();
            this.DataContext = this;
            listAllAlergens = loadJason();
           // listAlergens = newAlergens; //selektovani se dodaju
            window = w;

        }

        public ObservableCollection<Alergens> loadJason()
        {
            AlergensFileStorage afs = new AlergensFileStorage();
            ObservableCollection<Alergens> ret = new ObservableCollection<Alergens>(afs.GetAll());

            return ret;
        }

        private void AddAlergens(object sender, RoutedEventArgs e)
        {
            //AlergensFileStorage afs = new AlergensFileStorage();

            //listAlergens.Add((Alergens)all.SelectedItem);
            // listAllAlergens.Remove((Alergens)all.SelectedItem);
            var item = listAllAlergens[all.CurrentCell.Column.DisplayIndex];
            listAlergens.Add(item);
            listAllAlergens.Remove(item);

            all.ItemsSource = listAllAlergens;
            selected.ItemsSource = listAlergens;

            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            PatientFileStorage pfs = new PatientFileStorage();

            













        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
