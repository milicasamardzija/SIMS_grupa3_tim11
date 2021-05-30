using Hospital.Controller;
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
        public ObservableCollection<Checkup> appointmentList;
        public int index;
        public int id;

        CheckupController checkupController;
        FunctionalityController functionalityController;
        public ObrisiTermin(ObservableCollection<Checkup> list, Checkup selectedApp, int selectedIndex)
        {
            InitializeComponent();
            appointmentList = list;
            id = selectedApp.Id;
            index = selectedIndex;
            checkupController = new CheckupController();
            functionalityController = new FunctionalityController();
        }

        private void da_Click(object sender, RoutedEventArgs e)
        {
            
            checkupController.DeleteById(id);
            appointmentList.RemoveAt(index);

            Functionality funkcionalnost = new Functionality(DateTime.Now, id, "brisanje");
            functionalityController.save(funkcionalnost);


            this.Close();
        }

        private void ne_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
