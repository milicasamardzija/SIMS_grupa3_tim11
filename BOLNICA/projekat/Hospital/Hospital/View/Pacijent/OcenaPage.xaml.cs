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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for OcenaPage.xaml
    /// </summary>
    public partial class OcenaPage : Page
    {
        public int id { get; set; }


        public ObservableCollection<Checkup> termini
        {
            get;
            set;
        }
        private PocetnaPacijent parent;
        public OcenaPage(PocetnaPacijent p)
        {

            InitializeComponent();
            this.DataContext = this;
            parent = p;
            id = p.id;
            termini = loadJason();
            bolnica.IsEnabled = false;

           



            if (termini.Count > 5)
            {
                bolnica.IsEnabled = true;
            }

        }
        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new PacijentPPage(parent);
        }
        private void oceni_doktora(object sender, RoutedEventArgs e)
        {
          
            parent.startWindow.Content = new AnketaPage(parent, termini, (Checkup)ListaObavljenihTermina.SelectedItem, ListaObavljenihTermina.SelectedIndex);



        }
        public ObservableCollection<Checkup> loadJason()
        {
            CheckupFileStorage fs = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            ObservableCollection<Checkup> rs = new ObservableCollection<Checkup>(fs.GetAll());
            ObservableCollection<Checkup> ret = new ObservableCollection<Checkup>();

            foreach (Checkup appointment in rs)
            {
                if (appointment.IdPatient == id)
                {
                    if (DateTime.Now > appointment.Date)
                    {
                        ret.Add(appointment);
                    }
                }
            }

            return ret;
        }

        private void ocenite_bolnicu(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new OcenaBolnica(parent);
        }



        public void UpdateTable()
        {
            ListaObavljenihTermina.Items.Remove(((Checkup)ListaObavljenihTermina.SelectedItem).Id);
        }

        private void ListaObavljenihTermina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
