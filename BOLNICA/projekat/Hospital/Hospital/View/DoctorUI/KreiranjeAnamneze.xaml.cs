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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for KreiranjeAnamneze.xaml
    /// </summary>
    public partial class KreiranjeAnamneze : Window
    {
        public ObservableCollection<CheckupDTO> listCheckup;
        IAnamnesisFileStorage storageAnamnesis = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
        ObservableCollection<Anamnesis> listAnamnesis = new ObservableCollection<Anamnesis>();
        public CheckupDTO checkup;
        public int index;

        public KreiranjeAnamneze(ObservableCollection<CheckupDTO> list, CheckupDTO selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            index = selectedIndex;
        }

        public int generateIdAnamnesis()
        {
            int returnAnamnesis = 0;
            IAnamnesisFileStorage storageAnamnesis = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
            List<Anamnesis> allAnamnesis = storageAnamnesis.GetAll();
            foreach (Anamnesis anamnesisAll in allAnamnesis)
            {
                foreach (Anamnesis anamnesis in allAnamnesis)
                {
                    if (returnAnamnesis == anamnesis.Id)
                    {
                        ++returnAnamnesis;
                        break;
                    }
                }
            }
            return returnAnamnesis;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Anamnesis newAnamnesis = new Anamnesis(generateIdAnamnesis(), Convert.ToString(textIme), Convert.ToString(textPol.Text),
               Convert.ToString(textDatum.Text), Convert.ToInt16(textId.Text), Convert.ToString(textAdresa.Text), 
               Convert.ToString(textBrak.Text), Convert.ToString(textZanimanje.Text), Convert.ToString(textZakljucak.Text));
           
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
