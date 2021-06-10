using Hospital.Controller;
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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for ObavljeniPage.xaml
    /// </summary>
    public partial class ObavljeniPage : Page
    {
        private PocetnaPacijent parent;
        int id;
        PatientController patientController = new PatientController();
        public static Anamnesis selektovanaAnamneza;

        public ObavljeniPage(PocetnaPacijent p)
        {
            InitializeComponent();
            parent = p;
            id = p.id;
            this.DataContext = this;
            dodajbtn.IsEnabled = false;
            FillTable();


          
        }

        private void FillTable()
        {
            AnamnesisFileStorage storage = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
            List<Anamnesis> anamneses = storage.GetAll();
            foreach (Anamnesis a in anamneses)
            {

                Anamneza.Items.Add(a);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selektovanaAnamneza = (Anamnesis)Anamneza.SelectedItem;
            parent.startWindow.Content = new AnamnezaPage(parent, selektovanaAnamneza);


        }

        private void DataGridAnamneses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new KartonPage(parent);

        }

        private void ShowNotesForAnamnesis(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new AnamnezaPage(parent,selektovanaAnamneza);


        }

        private void Anamneza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selektovanaAnamneza = (Anamnesis)Anamneza.SelectedItem;
            dodajbtn.IsEnabled = true;

        }
    }
}
