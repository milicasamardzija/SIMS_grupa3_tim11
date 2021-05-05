using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



    public class NoticeFileStorage
    {
 

    public List<Notice> GetAll()
    {
        List<Notice> allNotices = new List<Notice>();
        allNotices = JsonConvert.DeserializeObject<List<Notice>>(File.ReadAllText(@"./../../../../Hospital/files/notices.json"));
        return allNotices;
    }

   /* public void saveAll(Notice notices)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/notices.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, notices);

        }
    } */
    //nisam sigurna hoce li raditi
    internal void save(Notice rs)
    {
        List<Notice> allNotice = GetAll();
        allNotice.Add(rs);
        SaveAll(allNotice);
    }

    public void SaveAll(List<Notice> all)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/notices.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file,all);

        }
    }
}
