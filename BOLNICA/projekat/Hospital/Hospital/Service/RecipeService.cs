﻿using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.Service
{
    public class RecipeService
    {
        public RecipeFileStorage storageRecipe;

        public RecipeService()
        {
            storageRecipe = new RecipeFileStorage("./../../../../Hospital/files/recepti.json");
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
        
    }
}