using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.AProcesses
{
    static class UserAndJson
    {
        static string UserPath = "C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json";
        public static List<User> ReadFromJson()
        {
            List<User> users;
            using (StreamReader sr = new StreamReader(UserPath))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            return users;
        }

        public static void AddToJson(User u)
        {
            List<User> users = ReadFromJson();
            int MaxId = 1;
            foreach (User user in users)
            {
                if (user.Id > MaxId)
                    MaxId = user.Id;
            }
            u.Id = MaxId + 1;
            users.Add(u);

            using (StreamWriter sw = new StreamWriter(UserPath))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }
        }

    }
}
