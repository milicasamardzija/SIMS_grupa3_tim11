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
    /// Interaction logic for KreiranjeAnamneze.xaml
    /// </summary>
    public partial class KreiranjeAnamneze : Window
    {
        public ObservableCollection<Checkup> listCheckup;
        public Checkup checkup;
        public int idx;

        public KreiranjeAnamneze(ObservableCollection<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            idx = selectedIndex;
            textIme.SelectedText = Convert.ToString(selectedCheckup.patient);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AnamnesisFileStorage st = new AnamnesisFileStorage();
            List<Anamnesis> listAna = new List<Anamnesis>();
            int id = 1;
            Anamnesis a = new Anamnesis(id, Convert.ToString(textIme), Convert.ToString(textPol.Text), Convert.ToString(textDatum.Text),
                Convert.ToString(textAdresa.Text), Convert.ToString(textBrak.Text), Convert.ToString(textZanimanje.Text),
                Convert.ToString(textZakljucak.Text));
            st.Save(a);
            listAna.Add(a);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //AnamnesisFileStorage storage = new AnamnesisFileStorage();
           // ObservableCollection<Anamnesis> aa = new ObservableCollection<Anamnesis>(storage.GetAll());
            PostojeceAnamneze pa = new PostojeceAnamneze();
            pa.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
