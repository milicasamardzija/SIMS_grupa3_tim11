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
    /// Interaction logic for UputZaAmbulantnoSpecijalistickiPregled.xaml
    /// </summary>
    public partial class UputZaAmbulantnoSpecijalistickiPregled : Window
    {

        public void dodajLekara()
        {
            DoctorFileStorage doctorStorage = new DoctorFileStorage();
            foreach(Doctor doctor in doctorStorage.GetAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = doctor.doctorId;

                doktori.Items.Add(item);
            }
        }

        public UputZaAmbulantnoSpecijalistickiPregled()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int generateID()
        {
            int ret = 0;
            InstructionFileStorage storage = new InstructionFileStorage();
            List<Instruction> all = storage.GetAll();
            foreach (Instruction instructions in all)
            {
                foreach (Instruction instruction in all)
                {
                    if (ret == instruction.IdInstruction)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InstructionFileStorage instructionStorage = new InstructionFileStorage();
            List<Instruction> instructionList = new List<Instruction>();

            Instruction instruction = new Instruction(generateID(), Convert.ToString(upucujeText.Text),
                Convert.ToString(jmbgText.Text), Convert.ToString(lboText.Text), Convert.ToInt16(registarskiBrojText.Text),
                Convert.ToString(jmbgText.Text), doktori, Convert.ToString(trajeText.Text), Convert.ToString(razlogText.Text));
            instructionStorage.Save(instruction);
            instructionList.Add(instruction);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregledLekar zpl = new ZakaziPregledLekar();
            zpl.Show();
        }
    }
}
