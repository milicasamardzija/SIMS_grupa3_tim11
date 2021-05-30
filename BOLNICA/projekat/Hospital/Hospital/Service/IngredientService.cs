using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;

namespace Hospital.Service
{
    public class IngredientService
    {
        private IngredientsIFileStorage ingredientsStorage;

        public IngredientService()
        {
            ingredientsStorage = new IngredientsFileStorage("./../../../../Hospital/files/storageIngredients.json");
        }

        public List<Ingredient> getAll()
        {
            return ingredientsStorage.GetAll();
        }

        public List<Ingredient> loadMedicineIngredients(Medicine medicine)
        {
            return ingredientsStorage.loadMedicineIngredients(medicine);
        }
        public List<int> convertIngredientsIntoIds(List<Ingredient> ingredientsMedicine)
        {
            List<int> ingredientsIds = new List<int>();
            foreach (Ingredient ingredient in ingredientsMedicine)
            {
                ingredientsIds.Add(ingredient.Id);
            }
            return ingredientsIds;
        }
    }
}
