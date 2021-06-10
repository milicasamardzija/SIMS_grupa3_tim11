using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for AnamnezaPage.xaml
    /// </summary>
    public partial class AnamnezaPage : Page
    {
        int id;
        private Anamnesis selectedAnamnesis;
        private Boolean OnReminder;
        private Note note;
        PatientController patientController;
        private PocetnaPacijent parent;
        public AnamnezaPage(PocetnaPacijent p, Anamnesis selected)
        {
            InitializeComponent();
            parent = p;
            selectedAnamnesis = selected;
            note = new Note();
            BlackOutDates();
            patientController = new PatientController();

            startDatePicker.Visibility = Visibility.Hidden;
            endDatePicker.Visibility = Visibility.Hidden;
            startDateTextBlock.Visibility = Visibility.Hidden;
            endDateTextBlock.Visibility = Visibility.Hidden;
            OnReminder = false;


        }

        private void BlackOutDates()
        {
            CalendarDateRange calendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            startDatePicker.BlackoutDates.Add(calendar);
            endDatePicker.BlackoutDates.Add(calendar);
            addNote.IsEnabled = false;


        }

        private void addNote_Click(object sender, RoutedEventArgs e)
        {

            String textOfNote = textBox.Text;
            if (OnReminder == false)
            {
                note.description = textOfNote;
                note.StartDate = DateTime.MinValue;
                note.EndDate = DateTime.MinValue;

                if (selectedAnamnesis.NotesForAnamnesis != null)
                {
                    selectedAnamnesis.NotesForAnamnesis.Add(note);
                }
                else
                {
                    List<Note> notes = new List<Note>();
                    notes.Add(note);
                    selectedAnamnesis.NotesForAnamnesis = notes;
                }

                AnamnesisFileStorage storage = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");


                storage.DeleteById(0);
                storage.Save(selectedAnamnesis);
                parent.startWindow.Content = new ObavljeniPage(parent);

            }
            else
            {
                note.description = textOfNote;
                note.StartDate = (DateTime)startDatePicker.SelectedDate;
                note.EndDate = (DateTime)endDatePicker.SelectedDate;
                note.IsSetReminder = true;

                if (selectedAnamnesis.NotesForAnamnesis != null)
                {
                    selectedAnamnesis.NotesForAnamnesis.Add(note);
                }
                else
                {
                    List<Note> notes = new List<Note>();
                    notes.Add(note);
                    selectedAnamnesis.NotesForAnamnesis = notes;
                }


                AnamnesisFileStorage storage = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");


                storage.DeleteById(0);
                storage.Save(selectedAnamnesis);
                parent.startWindow.Content = new ObavljeniPage(parent);
               
            }



        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            parent.startWindow.Content = new ObavljeniPage(parent);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButtonSubmit();

        }

        private void StartDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CalendarDateRange calendar = new CalendarDateRange(DateTime.MinValue, (DateTime)startDatePicker.SelectedDate);
            endDatePicker.IsEnabled = true;
            endDatePicker.BlackoutDates.Add(calendar);
            SetEnabledButtonSubmit();
        }


        private void SetEnabledButtonSubmit()
        {

            if (OnReminder == true)
            {
                if (startDatePicker.SelectedDate != null && endDatePicker.SelectedDate != null &&
                    textBox.Text != null)
                {
                    addNote.Visibility = Visibility.Visible;
                    addNote.IsEnabled = true;
                }

                else
                {
                    addNote.IsEnabled = false;
                }
            }
            else
            {
                if (textBox.Text != null)
                {
                    addNote.IsEnabled = true;
                }
                else
                {
                    addNote.IsEnabled = false;
                }
            }

        }


        private void odustani(object sender, RoutedEventArgs e)
        {

        }

        private void reminderButton_Click(object sender, RoutedEventArgs e)
        {
            OnReminder = true;
            
            startDatePicker.Visibility = Visibility.Visible;
            endDatePicker.Visibility = Visibility.Visible;
            startDateTextBlock.Visibility = Visibility.Visible;
            endDateTextBlock.Visibility = Visibility.Visible;

        }

        private void EndDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButtonSubmit();
        }
    }
}
