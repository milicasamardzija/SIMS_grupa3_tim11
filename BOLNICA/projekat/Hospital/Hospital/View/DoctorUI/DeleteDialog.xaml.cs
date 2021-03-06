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
using Hospital.Model;
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DeleteDialog.xaml
    /// </summary>
    public partial class DeleteDialog : Window
    {

        public ObservableCollection<CheckupDTO> listCheckup;
        public CheckupDTO checkup = new CheckupDTO();
        public int indexCheckup;
        public int idCheckup;
        public CheckupController controller = new CheckupController();

        public DeleteDialog(ObservableCollection<CheckupDTO> list, CheckupDTO selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            indexCheckup = selectedIndex;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            controller.DeleteById(idCheckup);
            listCheckup.RemoveAt(indexCheckup);
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
