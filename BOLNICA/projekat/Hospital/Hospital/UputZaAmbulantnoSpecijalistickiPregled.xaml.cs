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
using Hospital.Model;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for UputZaAmbulantnoSpecijalistickiPregled.xaml
    /// </summary>
    public partial class UputZaAmbulantnoSpecijalistickiPregled : Window
    {

        public UputZaAmbulantnoSpecijalistickiPregled()
        {
            InitializeComponent();
        }

        public int generateInstructionId()
        {
            int ret = 0;
            InstructionFileStorage storage = new InstructionFileStorage();
            List<Instruction> all = storage.GetAll();
            foreach (Instruction instruction in all)
            {
                foreach (Instruction instructions in all)
                {
                    if (ret == instructions.idInstruction)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public int getCheckupFromFile()
        {
            int ret = 0;
            CheckupFileStorage storage = new CheckupFileStorage();
            List<Checkup> all = storage.GetAll();
            foreach (Checkup checkup in all)
            {
                foreach (Checkup checkups in all)
                {
                    if (ret == checkups.IdCh)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InstructionFileStorage storageInstruction = new InstructionFileStorage();
            String typeInstruction = "ambulantno-specijalisticki pregled";
            bool instructionIsGiven = true;
            List<Instruction> instructionList = new List<Instruction>();

            Instruction newInstruction = new Instruction(generateInstructionId(), getCheckupFromFile(), typeInstruction, instructionIsGiven,
                Convert.ToString(jmbgUText.Text), Convert.ToString(lboUText.Text), Convert.ToString(intervalText.Text),
                Convert.ToString(razlogText.Text));

            storageInstruction.Save(newInstruction);
            instructionList.Add(newInstruction);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregledLekar zpl = new ZakaziPregledLekar();
            zpl.Show();
        }
    }
}
