using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class FunkcionalnostiFileStorage
    {
        public List<Koristenjefunkcionalnosti> GetAll()
        {
            List<Koristenjefunkcionalnosti> funkcionalnosti = new List<Koristenjefunkcionalnosti>();
            funkcionalnosti = JsonConvert.DeserializeObject<List<Koristenjefunkcionalnosti>>(File.ReadAllText(@"./../../../../Hospital/files/count.json"));
            return funkcionalnosti;
        }

        public void Save(Koristenjefunkcionalnosti funkcionalnost)
        {
            List<Koristenjefunkcionalnosti> app = GetAll();
            app.Add(funkcionalnost);
            SaveAll(app);
        }

        public void SaveAll(List<Koristenjefunkcionalnosti> funkcionalnosti)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/count.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, funkcionalnosti);
            }
        }

      
      
        public Koristenjefunkcionalnosti FindById(string id)
        {

            List<Koristenjefunkcionalnosti> funkcionalnosti = GetAll();
            Koristenjefunkcionalnosti app = null;

            foreach (Koristenjefunkcionalnosti funkcionalnost in funkcionalnosti)
            {
                if (funkcionalnost.vrstaFunkconalnosti == id)
                {
                    app = funkcionalnost;
                    break;
                }
            }

            return app;
        }

        public Boolean ExistsById(int id)
        {
            List<Koristenjefunkcionalnosti> termini = GetAll();
            Boolean app = false;

            foreach (Koristenjefunkcionalnosti termin in termini)
            {
            //    if (termin.idA == id)
                {
                    app = true;
                    break;
                }
            }
            return app;

        }
        public String fileLocation;
    }
}
