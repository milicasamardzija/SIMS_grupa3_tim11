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
using System.Windows.Shapes;

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for PrikazBiljeski.xaml
    /// </summary>
    public partial class PrikazBiljeski : Window
    {
        int id;
        private Anamnesis selectedAnamnesis;
        public PrikazBiljeski(int idP,  Anamnesis selected)
        {
            InitializeComponent();

            id = idP;
            selectedAnamnesis = selected;
            
        }


        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateListView()
        {
            AnamnesisFileStorage anamneze = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
            List<Note> notes = new List<Note>();
            foreach (Anamnesis a in anamneze.GetAll())
            {
              
                    foreach (Note n in a.NotesForAnamnesis)
                    {
                        notes.Add(n);
                    }
                
            }
             


            foreach (Note n in notes)
            {
                showNotesListView.Items.Add(n.description);
            }
        }
    }
}




