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
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for UputZaAmbulantnoSpecijalistickiPregled.xaml
    /// </summary>
    public partial class UputZaAmbulantnoSpecijalistickiPregled : Window
    {
        public List<CheckupDTO> CheckupList { get; set; }
        public int idDoctor;
        public InstructionController controller = new InstructionController();
        public Instruction instruction;

        public UputZaAmbulantnoSpecijalistickiPregled()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // controller.createInstruction(instruction);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregledLekar newCheckupInstruction = new ZakaziPregledLekar(CheckupList, idDoctor);
            newCheckupInstruction.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
