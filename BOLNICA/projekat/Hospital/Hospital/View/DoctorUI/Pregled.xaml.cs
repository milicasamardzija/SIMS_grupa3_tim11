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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using Hospital.Model;
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;
using Hospital.View.DoctorUI;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        public ObservableCollection<CheckupDTO> CheckupList { get; set; }
        public CheckupDTO checkup = new CheckupDTO();
        public CheckupController checkupController = new CheckupController();
        public int idSignedDoctor;
        public PatientDTO patient;
        public int index;

        public Pregled(int idDoctor)
        {
            InitializeComponent();
            this.DataContext = this;
            idSignedDoctor = idDoctor;
            CheckupList = new ObservableCollection<CheckupDTO>(checkupController.getAll());
        }
        
        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog addDialog = new AddDialog(CheckupList, idSignedDoctor);
            addDialog.Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditDialog editDialog = new EditDialog(CheckupList, (CheckupDTO)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            editDialog.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog deleteDialog = new DeleteDialog(CheckupList, (CheckupDTO)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            deleteDialog.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            PregledPacijenata showPatients = new PregledPacijenata();
            showPatients.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            IzdavanjeRecepta giveRecipe = new IzdavanjeRecepta();
            giveRecipe.Show();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            KreiranjeAnamneze newAnamnesis = new KreiranjeAnamneze(CheckupList, (CheckupDTO)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            newAnamnesis.Show();
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            EvidencijaLekar recordDoctor = new EvidencijaLekar();
            recordDoctor.Show();
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            PovratneInformacijeLekar informations = new PovratneInformacijeLekar();
            informations.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzvestajLekara reportDoctor = new IzvestajLekara();
            reportDoctor.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ProfilLekara profileDoctor = new ProfilLekara();
            profileDoctor.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DavanjeUputa giveInstructions = new DavanjeUputa();
            giveInstructions.Show();
        }

    }
}
