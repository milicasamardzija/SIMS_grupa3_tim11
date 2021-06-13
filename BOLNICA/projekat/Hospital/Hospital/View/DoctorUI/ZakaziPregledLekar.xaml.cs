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
using Newtonsoft.Json;
using System.IO;
using Hospital.Controller;
using Hospital.DTO;
using System.Collections.ObjectModel;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for ZakaziPregledLekar.xaml
    /// </summary>
    public partial class ZakaziPregledLekar : Window
    {
        public ObservableCollection<CheckupDTO> listCheckup;
        public CheckupDTO checkup = new CheckupDTO();
        public int idDoctor;
        public InstructionController controllerInstruction = new InstructionController();

        public ZakaziPregledLekar(ObservableCollection<CheckupDTO> list, int id)
        {
            InitializeComponent();
            listCheckup = list;
            idDoctor = id;

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(kalendar);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            controllerInstruction.newCheckup(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
