using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;



    public class NoticeFileStorage
    {
 

    public ObservableCollection<Notice> GetAll()
    {
        ObservableCollection<Notice> allNotices = new ObservableCollection<Notice>();
        allNotices = JsonConvert.DeserializeObject<ObservableCollection<Notice>>(File.ReadAllText(@"./../../../../Hospital/files/notices.json"));
        return allNotices;
    }


    public void save(Notice rs)
    {
        ObservableCollection<Notice> allNotice = GetAll();
        allNotice.Add(rs);
        SaveAll(allNotice);
    }

    public void SaveAll(ObservableCollection<Notice> all)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/notices.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file,all);

        }
    }

    public void Delete(Notice notes)
    {
        ObservableCollection<Notice> allPatients = GetAll();

        foreach (Notice p in allPatients)
        {
            if (p.id == notes.id)
            {
                allPatients.Remove(p);
                break;
            }
        }
        SaveAll(allPatients);
    }
}
