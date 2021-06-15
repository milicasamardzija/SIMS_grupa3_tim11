using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.Service
{
    public class RecipeService
    {
        private IRecipeFileStorage storageRecipe;

        public RecipeService(IRecipeFileStorage storageRecipe)
        {
           this.storageRecipe = storageRecipe;
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


        public List<Recipe> getAll()
        {
            return storageRecipe.GetAll();
        }
        public List<Recipe> getbyId(int id)
        {
            List<Recipe> recipes = storageRecipe.GetAll();
            List<Recipe> patientRecipe = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {

                if (recipe.Id == id)
                {

                    patientRecipe.Add(recipe);
                }
            }
            return patientRecipe;
        }
    }
}
