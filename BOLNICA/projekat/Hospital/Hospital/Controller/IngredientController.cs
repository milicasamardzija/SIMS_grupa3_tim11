using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class IngredientController
    {
        private IngredientService ingredientService;

        public IngredientController()
        {
            ingredientService = new IngredientService();
        }
        public List<IngredientDTO> getAll()
        {
            List<IngredientDTO> ingredients = new List<IngredientDTO>();
            foreach (Ingredient ingredient in ingredientService.getAll())
            {
                ingredients.Add(new IngredientDTO(ingredient.Id,ingredient.Name,ingredient.Quantity));
            }
            return ingredients;
        }

        public List<IngredientDTO> loadMedicineIngredients(MedicineDTO medicine)
        {
            List<IngredientDTO> ingredients = new List<IngredientDTO>();
            foreach (Ingredient ingredient in ingredientService.loadMedicineIngredients(new Medicine(medicine.Id,medicine.Name,medicine.Quantity,medicine.Type,medicine.IdsIngredients,medicine.IdsMedicines,medicine.Approved)))
            {
                ingredients.Add(new IngredientDTO(ingredient.Id, ingredient.Name, ingredient.Quantity));
            }
            return ingredients;
        }

        public List<int> convertReplacementMedicinesIntoIds(List<IngredientDTO> ingredientsMedicine)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (IngredientDTO ingredient in ingredientsMedicine)
            {
                ingredients.Add(new Ingredient(ingredient.Id, ingredient.Name, ingredient.Quantity));
            }
            return ingredientService.convertIngredientsIntoIds(ingredients);
        }
    }
}
