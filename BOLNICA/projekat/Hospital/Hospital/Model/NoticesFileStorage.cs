using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


public class NoticesFileStorage
{

    public List<Notices> GetAll()
    {
        List<Notices> allNotices = new List<Notices>();

        allNotices = JsonConvert.DeserializeObject<List<Notices>>(File.ReadAllText(@"./../../../../Hospital/files/noticeForEmployees.json"));

        return allNotices;
    }

    public void SaveAll(List<Notices> notices)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/noticeForEmployee.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, notices);
        }
    }
}
