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
        public List<Checkup> listCheckup;
        public Checkup checkup;
        public int indexCheckup;

        public KreiranjeAnamneze(List<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            indexCheckup = selectedIndex;
            textIme.SelectedText = Convert.ToString(selectedCheckup.Patient);
        }

        public int generateIdAnamnesis()
        {
            int ret = 0;
            AnamnesisFileStorage storage = new AnamnesisFileStorage(@"./../../../../Hospital/files/anamnesis.json");
            List<Anamnesis> allAnamnesis = storage.GetAll();
            foreach (Anamnesis anamnesis in allAnamnesis)
            {
                foreach (Anamnesis anamnesisAll in allAnamnesis)
                {
                    if (ret == anamnesisAll.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AnamnesisFileStorage storageAnamnesis = new AnamnesisFileStorage(@"./../../../../Hospital/files/anamnesis.json");
            List<Anamnesis> listAnamnesis = new List<Anamnesis>();
            
            Anamnesis newAnamnesis = new Anamnesis(generateIdAnamnesis(), Convert.ToString(textIme), Convert.ToString(textPol.Text), Convert.ToString(textDatum.Text),
                Convert.ToString(textAdresa.Text), Convert.ToString(textBrak.Text), Convert.ToString(textZanimanje.Text),
                Convert.ToString(textZakljucak.Text));

            storageAnamnesis.Save(newAnamnesis);
            listAnamnesis.Add(newAnamnesis);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            PostojeceAnamneze existingAnamnesis = new PostojeceAnamneze();
            existingAnamnesis.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
