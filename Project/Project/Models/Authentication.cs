using Newtonsoft.Json;
using Project.AProcesses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    static class Authentication
    {
        public static bool AuthUser(string username, string password)
        {
            List<User> users;
            users = UserAndJson.ReadFromJson();
            foreach (User u in users)
                if (u.Username == username && u.Password == password)
                   return true;

            return false;
        }

        public static bool IsContainUsername(string username)
        {
            List<User> users;
            users = UserAndJson.ReadFromJson();

            foreach (User u in users)
            {
                if (u.Username == username)
                    return true;
            }
            return false;
        }




    }
}
