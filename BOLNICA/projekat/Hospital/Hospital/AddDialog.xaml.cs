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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public ObservableCollection<Checkup> listCheckup;

        public AddDialog(ObservableCollection<Checkup> list)
        {
            InitializeComponent();
            listCheckup = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            Checkup newCheckup = new Checkup(dateText.Text, timeText.Text, Convert.ToDouble(durationText.Text), (CheckupType)comboBox.SelectedIndex, patientText.Text);
            st.Save(newCheckup);
            listCheckup.Add(newCheckup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
