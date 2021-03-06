using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Window
    {
        public IAlergensFileStorage storage = new AlergensFileStorage("./../../../../Hospital/files/alergens.json");
        private IRecipeFileStorage storageRecipe = new RecipeFileStorage(@"./../../../../Hospital/files/recepti.json");
        public List<Recipe> recipeList = new List<Recipe>();
        public PatientDTO patient = new PatientDTO();

        public IzdavanjeRecepta()
        {
            InitializeComponent();
            textBox1.SelectedText = Convert.ToString(patient.Id);
            textBox3.SelectedText = Convert.ToString(patient.IdHealthCard);
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            datePicker.BlackoutDates.Add(kalendar);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public int generateID()
        {
            int returnRecipe = 0;
            IRecipeFileStorage storage = new RecipeFileStorage("./../../../../Hospital/files/recepti.json");
            List<Recipe> allRecipe = storage.GetAll();
            foreach (Recipe recipes in allRecipe)
            {
                foreach (Recipe recipe in allRecipe)
                {
                    if (returnRecipe == recipe.Id)
                    {
                        ++returnRecipe;
                        break;
                    }
                }
            }
            return returnRecipe;
        }

        public void mesage()
        {
            foreach (Alergens alergen in storage.GetAll())
            {
                if (Convert.ToInt16(textBox7.Text) == alergen.Id)
                {
                    MessageBox.Show("Pacijent je alergican na lek! Unesite novi lek, molim.");
                    break;
                }
               /* else
                {
                    MessageBox.Show("Lek je prihvacen!");
                    break;
                }*/
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mesage();

            Recipe newRecipe = new Recipe(generateID(), Convert.ToString(textBox.Text), Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text),
                Convert.ToString(textBox3.Text), datePicker.DisplayDate, Convert.ToString(textBox5.Text),
                Convert.ToInt16(textBox6.Text), Convert.ToInt16(textBox7.Text), Convert.ToString(textBox8.Text), Convert.ToString(textBox9.Text),
                Convert.ToString(textBox10.Text), Convert.ToDateTime(textBox11.Text), Convert.ToDateTime(textBox12.Text),
                Convert.ToInt16(textBox13.Text));

            storageRecipe.Save(newRecipe);
            recipeList.Add(newRecipe);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
