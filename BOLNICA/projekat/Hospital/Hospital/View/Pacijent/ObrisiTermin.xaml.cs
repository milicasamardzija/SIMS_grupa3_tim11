using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for ObrisiTermin.xaml
    /// </summary>
    public partial class ObrisiTermin : Window
    {

        CheckupController checkupController;
        FunctionalityController functionalityController;
        public ObservableCollection<CheckupDTO> appointmentList;
        public int index;
        public int id;

        public ObrisiTermin(ObservableCollection<CheckupDTO> list, CheckupDTO selectedApp, int selectedIndex)
        {
            InitializeComponent();
            appointmentList = list;
            id = selectedApp.IdCh;
            index = selectedIndex;
            checkupController = new CheckupController();
            functionalityController = new FunctionalityController();
        }

        private void da_Click(object sender, RoutedEventArgs e)
        {
            
            checkupController.DeleteById(id);
            appointmentList.RemoveAt(index);

            FunctionalityDTO funkcionalnost = new FunctionalityDTO(id,DateTime.Now, id, "brisanje");
            functionalityController.save(funkcionalnost);


            this.Close();
        }

        private void ne_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
