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
using Hospital.DTO;

namespace Hospital
{
    public partial class BrisanjeLekaRevizijaUpravnik : UserControl
    {
        private Frame frame;
        private MedicineDTO medicine = new MedicineDTO();
        public MedicineDTO Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }

        private MedicineController controller;
        public BrisanjeLekaRevizijaUpravnik(MedicineDTO medicine, Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.medicine = medicine;
            this.frame = frame;
            controller = new MedicineController();

            NazivTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TipTxt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dodajSpecijalizacije();
        }

        public void dodajSpecijalizacije()
        {
            SpecijalizacijaComboBox.ItemsSource = Enum.GetValues(typeof(SpecializationType));
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
        public List<Doctor> doktoriPoSpecijalizaciji()
        {
            DoctorFileStorage storage = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
            List<Doctor> filtratedDoctors = new List<Doctor>();
            foreach (Doctor doctor in storage.GetAll())
            {
                if (doctor.SpecializationType == (SpecializationType)SpecijalizacijaComboBox.SelectedItem)
                {
                    filtratedDoctors.Add(doctor);
                }
            }

            return filtratedDoctors;
        }
        private void getDoctors(object sender, SelectionChangedEventArgs e)
        {
            LekarComboBox.Items.Clear();
            List<Doctor> doctors = doktoriPoSpecijalizaciji();
            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = doctor.Name + "  " + doctor.Surname;
                item.Tag = doctor.Id;
                LekarComboBox.Items.Add(item);
            }
        }
    }
}
