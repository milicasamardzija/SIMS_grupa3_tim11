using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.IO;

namespace Hospital.Model
{
    class SurveyFileStorage
    {
        public List<Survey> GetAll()
        {
            List<Survey> allsurvey = new List<Survey>();

            allsurvey = JsonConvert.DeserializeObject<List<Survey>>(File.ReadAllText(@"./../../../../Hospital/files/ankete.json"));

            return allsurvey;
        }

        public void Save(Survey newSurvey)
        {
            List<Survey> app = GetAll();
            app.Add(newSurvey);
            SaveAll(app);
        }

        public void SaveAll(List<Survey> surveys)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/ankete.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, surveys);
            }
        }


        public void Delete(Survey survey)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Manager FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Boolean ExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
