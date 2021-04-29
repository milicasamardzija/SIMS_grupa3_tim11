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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class Pregled : Window
    {
        public ObservableCollection<Checkup> CheckupList
        {
            get;
            set;
        }

        public int id;
        public int idpacijenta = 1;

        public Pregled(int idDoctor)
        {
            InitializeComponent();
            this.DataContext = this;
            id = idDoctor;
            CheckupList = loadJson(id);
        }

        public ObservableCollection<Checkup> loadJson(int idD)
        {
            CheckupFileStorage cs = new CheckupFileStorage();
            ObservableCollection<Checkup> cc = new ObservableCollection<Checkup>(cs.GetAll()); //svi pregledi
            ObservableCollection<Checkup> ret = new ObservableCollection<Checkup>(); //ovde ce biti ubaceni pregledi koje ima bas lekar sa prosledjenim id-em(odnosno id lekara koji je ulogovan na sistem)

            foreach (Checkup checkup in cc) //prolazimo kroz sve preglede u fajlu
            {
                //if (checkup.doctor.doctorId == idD) //trazimo pregled koji ima doktora sa prosledjenim id-jem
                //{
                    ret.Add(checkup); //dodajemo taj pregled u listu koju vracamo za ispis u tabelu
                //}
            }
            return ret;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog ad = new AddDialog(CheckupList, id); //salje se i id doktora koji je ulogovan
            ad.Show();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditDialog ed = new EditDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            ed.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog dd = new DeleteDialog(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            dd.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            PregledPacijenata pp = new PregledPacijenata();
            pp.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow mw = new MainWindow();
            // mw.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            IzdavanjeRecepta ir = new IzdavanjeRecepta();
            ir.Show();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            KreiranjeAnamneze ka = new KreiranjeAnamneze(CheckupList, (Checkup)ListCheckups.SelectedItem, ListCheckups.SelectedIndex);
            ka.Show();
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            EvidencijaLekar el = new EvidencijaLekar();
            el.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzvestajLekara il = new IzvestajLekara();
            il.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ProfilLekara pl = new ProfilLekara();
            pl.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DavanjeUputa du = new DavanjeUputa();
            du.Show();
        }
    }
}
