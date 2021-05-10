using Hospital.Controller;
using Hospital.Model;
using System;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for BrisanjeLekaRevizijaUpravnik.xaml
    /// </summary>
    public partial class BrisanjeLekaRevizijaUpravnik : UserControl
    {
        private Frame frame = new Frame();
        private Medicine medicine = new Medicine();
        public Medicine Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }
        private MedicineController controller = new MedicineController();
        public BrisanjeLekaRevizijaUpravnik(Medicine selectedMedicine, Frame upravnikFrame)
        {
            InitializeComponent();
            this.DataContext = this;
            medicine = selectedMedicine;
            frame = upravnikFrame;

            NazivTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TipTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            dodajSpecijalizacije();
        }

        public void dodajSpecijalizacije()
        {

            SpecijalizacijaComboBox.ItemsSource = Enum.GetValues(typeof(SpecializationType));

        }

        public List<Doctor> doktoriPoSpecijalizaciji()
        {
            DoctorFileStorage storage = new DoctorFileStorage();
            List<Doctor> filtratedDoctors = new List<Doctor>();
            foreach (Doctor doctor in storage.GetAll())
            {
                if (doctor.specializationType == (SpecializationType)SpecijalizacijaComboBox.SelectedItem)
                {
                    filtratedDoctors.Add(doctor);
                }
            }

            return filtratedDoctors;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)LekarComboBox.SelectedItem;
            controller.deleteMedicine(medicine,Convert.ToInt32(item.Tag));
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void getDoctors(object sender, SelectionChangedEventArgs e)
        {
            LekarComboBox.Items.Clear();
            List<Doctor> doctors = doktoriPoSpecijalizaciji();
            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = doctor.Name + "  " + doctor.Surname;
                item.Tag = doctor.DoctorId;
                LekarComboBox.Items.Add(item);
            }
        }
    }
}
