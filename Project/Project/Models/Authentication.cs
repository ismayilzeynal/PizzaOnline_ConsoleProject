using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    static class Authentication
    {
        static string UserPath= "C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json";
        public static bool AuthUser(string username, string password)
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(UserPath))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            foreach (User u in users)
                if (u.Username == username && u.Password == password)
                   return true;

            return false;
        }

        public static bool IsContainUsername(string username)
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(UserPath))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }

            foreach (User u in users)
            {
                if (u.Username == username)
                    return true;
            }
            return false;
        }




    }
}
