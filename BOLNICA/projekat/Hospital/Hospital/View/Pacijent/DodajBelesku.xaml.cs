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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for DodajBelesku.xaml
    /// </summary>
    public partial class DodajBelesku : Window
    {
        public DodajBelesku()
        {
            InitializeComponent();
        }

        private void addNote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void StartDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CalendarDateRange calendar = new CalendarDateRange(DateTime.MinValue, (DateTime)startDatePicker.SelectedDate);
            endDatePicker.IsEnabled = true;
            endDatePicker.BlackoutDates.Add(calendar);
          //  SetEnabledButtonSubmit();
        }

        private void startMomentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

        }

        private void reminderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EndDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }
    }
}
