using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface IngredientsIFileStorage : GenericRepository<Ingredient>
    {
        List<Ingredient> loadMedicineIngredients(Medicine medicine);
    }
}
