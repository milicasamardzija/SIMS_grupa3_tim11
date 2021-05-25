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
using System.Collections.ObjectModel;
using Hospital.FileStorage.Interfaces;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for UputZaAmbulantnoSpecijalistickiPregled.xaml
    /// </summary>
    public partial class UputZaAmbulantnoSpecijalistickiPregled : Window
    {
        public List<Checkup> CheckupList { get; set; }
        public int idDoctor;

        public UputZaAmbulantnoSpecijalistickiPregled()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public int generateInstructionId()
        {
            int ret = 0;
            IInstructionFileStorage storageInstruction = new InstructionFileStorage("./../../../../Hospital/files/instructions.json");
            List<Instruction> allInstructions = storageInstruction.GetAll();
            foreach (Instruction instruction in allInstructions)
            {
                foreach (Instruction instructions in allInstructions)
                {
                    if (ret == instructions.Id)
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
            ICheckFileStorage storageCheckup = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storageCheckup.GetAll();
            foreach (Checkup checkup in allCheckups)
            {
                foreach (Checkup checkups in allCheckups)
                {
                    if (ret == checkups.Id)
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
            IInstructionFileStorage storageInstruction = new InstructionFileStorage("./../../../../Hospital/files/instructions.json");
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
            ZakaziPregledLekar newCheckupInstruction = new ZakaziPregledLekar(CheckupList, idDoctor);
            newCheckupInstruction.Show();
        }
    }
}
