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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Window
    {
        public IzdavanjeRecepta()
        {
            InitializeComponent();
            datePicker.DisplayDate = new DateTime(2021, 04, 17);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RecipeFileStorage st = new RecipeFileStorage();
            List<Recipe> recipeList = new List<Recipe>();
            int id = 1;
            Recipe r = new Recipe(id, Convert.ToString(textBox.Text), Convert.ToString(textBox1.Text), Convert.ToString(textBox2),
                Convert.ToString(textBox3), datePicker.DisplayDate, Convert.ToString(textBox5.Text),
                Convert.ToInt16(textBox6.Text), Convert.ToInt16(textBox7.Text), Convert.ToString(textBox8.Text), Convert.ToString(textBox9.Text),
                Convert.ToString(textBox10.Text), Convert.ToDateTime(textBox11.Text), Convert.ToDateTime(textBox12.Text),
                Convert.ToInt16(textBox13.Text));
            st.Save(r);
            recipeList.Add(r);
            //this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
