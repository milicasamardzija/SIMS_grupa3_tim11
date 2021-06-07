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

namespace Hospital
{
    public partial class BelsekaMagacin : UserControl
    {
        public string beleska;
        private ManagerNote notes = new ManagerNote();
        private List<ManagerNote> note = new List<ManagerNote>();
        private int id;
        public BelsekaMagacin(int id)
        {
            InitializeComponent();
            note = notes.GetAll();
            BeleskaTxt.Text = note[id].note;
            this.id = id;
        }

        private void sacuvaj(object sender, RoutedEventArgs e)
        {
            note[id].note = BeleskaTxt.Text;
            notes.SaveAll(note);
        }
    }
}
