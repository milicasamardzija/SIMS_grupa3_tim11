using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class IngredientsFileStorage
    {
        public List<Ingredient> GetAll()
        {
            List<Ingredient> all = new List<Ingredient>();

            all = JsonConvert.DeserializeObject<List<Ingredient>>(File.ReadAllText(@"./../../../../Hospital/files/storageIngredients.json"));

            return all;
        }

        public void Save(Ingredient newIngredient)
        {
            List<Ingredient> all = GetAll();

            all.Add(newIngredient);

            SaveAll(all);
        }

        public void SaveAll(List<Ingredient> ingredients)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageMedicine.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ingredients);
            }
        }

        public void Delete(Ingredient ingredient)
        {
            List<Ingredient> all = GetAll();

            foreach (Ingredient temp in all)
            {
                if (temp.IdIngredient == ingredient.IdIngredient)
                {
                    all.Remove(temp);
                    break;
                }
            }
            SaveAll(all);
        }

        public void DeleteById(int id)
        {
            List<Ingredient> all = GetAll();

            foreach (Ingredient ingredient in all)
            {
                if (ingredient.IdIngredient == id)
                {
                    all.Remove(ingredient);
                    break;
                }
            }
            SaveAll(all);
        }

        public Ingredient FindById(int id)
        {
            List<Ingredient> all = GetAll();
            Ingredient ret = null;

            foreach (Ingredient ingredient in all)
            {
                if (ingredient.IdIngredient == id)
                {
                    ret = ingredient;
                    break;
                }
            }

            return ret;
        }

        public Boolean ExistsById(int id)
        {
            List<Ingredient> all = GetAll();
            Boolean ret = false;

            foreach (Ingredient ingredient in all)
            {
                if (ingredient.IdIngredient == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
