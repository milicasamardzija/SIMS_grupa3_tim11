using Hospital.Controller;
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
        private AnamnesisController controller;
        public PrikazBiljeski(int idP,  Anamnesis selected)
        {
            InitializeComponent();

            id = idP;
            selectedAnamnesis = selected;
            controller = new AnamnesisController();
            UpdateListView();
        }


        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateListView()
        {

            foreach (Note n in controller.NotesForAnamnesis(selectedAnamnesis))
            {
                showNotesListView.Items.Add(n.description);
            }
        }
    }
}




