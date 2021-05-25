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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        public List<Checkup> CheckupList
        {
            get;
            set;
        }

        public int id;
        public int idPatient = 1;

        public Pregled(int idDoctor)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idDoctor;
            CheckupList = loadJson(id);
        }

        public List<Checkup> loadJson(int idD)
        {
            ICheckFileStorage storageCheckup = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = new List<Checkup>(storageCheckup.GetAll());
            List<Checkup> returnCheckup = new List<Checkup>(); 

            foreach (Checkup checkup in allCheckups) 
            {
                returnCheckup.Add(checkup); 
            }
            return returnCheckup;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog addDialog = new AddDialog(CheckupList, id);
            addDialog.Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditDialog editDialog = new EditDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            editDialog.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog deleteDialog = new DeleteDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
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
            KreiranjeAnamneze newAnamnesis = new KreiranjeAnamneze(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            newAnamnesis.Show();
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            EvidencijaLekar recordDoctor = new EvidencijaLekar();
            recordDoctor.Show();
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
