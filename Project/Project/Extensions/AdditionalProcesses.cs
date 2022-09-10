using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions
{
    static class AdditionalProcesses
    {
        public static void TryInt(out int choise)
        {
            while (!int.TryParse(Console.ReadLine(), out choise))
            {
                PEC();
            }
        }

        public static void PEC()
        {
            Console.WriteLine("Please enter correctly");
        }

        public static void End()
        {
            Console.Clear();
            Console.WriteLine("Thanks for using console app");
        }

        public static User FindUser(List<User> users, string username)
        {
            User user;
            foreach (User u in users)
            {
                if (u.Username == username)
                    return u;
            }
            user = null;
            return user;
        }
    }
}
