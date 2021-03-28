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
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {

        public ObservableCollection<Checkup> listCheckup;
        public Checkup checkup;
        public int index;

        public EditDialog(ObservableCollection<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            index = selectedIndex;

            dateText.SelectedText = selectedCheckup.date;
            timeText.SelectedText = selectedCheckup.time;
            durationText.SelectedText = Convert.ToString(selectedCheckup.duration);
            comboBox.SelectedIndex = (int)selectedCheckup.type;
            patientBox.SelectedText = selectedCheckup.patient;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            checkup.date = dateText.Text;
            checkup.time = timeText.Text;
            checkup.duration = Convert.ToDouble(durationText.Text);
            checkup.type = (CheckupType)comboBox.SelectedIndex;
            checkup.patient = patientBox.Text;

            //st.DeleteById(Convert.ToInt16(dateText.Text));
            st.Save(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
