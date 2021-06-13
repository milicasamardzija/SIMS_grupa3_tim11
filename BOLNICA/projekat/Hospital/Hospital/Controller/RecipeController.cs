using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class RecipeController
    {
        public RecipeService service;

        public RecipeController()
        {
            service = new RecipeService();
        }

        public List<Recipe> getbyId(int id)
        {
            return service.getbyId(id);
        }
        public List<Recipe> getAll()
        {

            return service.getAll();
        }
    }
}
