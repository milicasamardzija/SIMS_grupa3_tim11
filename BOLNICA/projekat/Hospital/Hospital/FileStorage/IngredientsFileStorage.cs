using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class IngredientsFileStorage : GenericFileStorage<Ingredient>, IngredientsIFileStorage
    {
        public IngredientsFileStorage(String filePath) : base(filePath) { }
        public List<Ingredient> loadMedicineIngredients(Medicine medicine)
        {
            List<Ingredient> ret = new List<Ingredient>();
            if (medicine != null)
            {
                foreach (int id in medicine.IdsIngredients)
                {
                    foreach (Ingredient ingredient in GetAll())
                    {
                        if (ingredient.Id == id)
                        {
                            ret.Add(ingredient);
                            break;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
