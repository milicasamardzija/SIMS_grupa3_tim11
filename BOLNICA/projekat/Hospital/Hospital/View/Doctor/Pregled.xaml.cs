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
        public List<Checkup> CheckupList
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

        public List<Checkup> loadJson(int idD)
        {
            CheckupFileStorage cs = new CheckupFileStorage();
            List<Checkup> cc = new List<Checkup>(cs.GetAll());
            List<Checkup> ret = new List<Checkup>(); 

            foreach (Checkup checkup in cc) 
            {
                //if (checkup.doctor.doctorId == idD) 
                //{
                    ret.Add(checkup); 
                //}
            }
            return ret;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog ad = new AddDialog(CheckupList, id); 
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
