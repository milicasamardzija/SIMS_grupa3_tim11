using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class AlergensFileStorage
    {
    public List<Alergens> GetAll()
    {
        List<Alergens> svi = new List<Alergens>();

        svi = JsonConvert.DeserializeObject<List<Alergens>>(File.ReadAllText(@"./../../../../Hospital/files/alergens.json"));
        return svi;
    }
    public void SaveAll(List<Alergens> alergens)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/alergens.json"))

        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, alergens);

        }
    }
}

