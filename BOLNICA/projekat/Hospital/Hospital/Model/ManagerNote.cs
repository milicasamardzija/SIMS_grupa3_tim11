using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class ManagerNote
    {
        public int id { get; set; }
        public String note { get; set; }


        public List<ManagerNote> GetAll()
        {
            List<ManagerNote> all = new List<ManagerNote>();

            all = JsonConvert.DeserializeObject<List<ManagerNote>>(File.ReadAllText("./../../../../Hospital/files/managerNote.json"));

            return all;
        }

        public void SaveAll(List<ManagerNote> entities)
        {
            using (StreamWriter file = File.CreateText("./../../../../Hospital/files/managerNote.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

    }
}
