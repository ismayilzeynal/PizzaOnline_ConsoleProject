using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Project.Extensions;
using Project.AProcesses;

namespace Project.Models
{
    static class LoginPage
    {
        static internal void FirstMenu(out int choise)
        {
            choise = -1;

            while (choise < 0 || choise > 2)
            {
                Console.Clear();
                Console.WriteLine("1) Login \n2) Register \n0) Exit");
                AdditionalProcesses.TryInt(out choise);
            }
        }


        static internal User Login()
        {
        LoginLabel:
            Console.Clear();
            User u = null;
            int choise = -1;
            Console.Write("Username: "); string Username = Console.ReadLine();
            Console.Write("Password: "); string Password = Console.ReadLine();

            if (Authentication.AuthUser(Username, Password))
            {
                List<User> users = new List<User>();
                users = UserAndJson.ReadFromJson();
                u = AdditionalProcesses.FindUser(users, Username);
                Console.WriteLine($"Welcome, {u.Name} {u.Surname}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid username or password\n");
                while (choise < 0 || choise > 2)
                {
                    Console.Clear();
                    Console.WriteLine("1) Try again \n2) Create new account \n0) Exit");
                    AdditionalProcesses.TryInt(out choise);
                }
                if (choise == 1)
                    goto LoginLabel;
                else if (choise == 2)
                    u = Register();
            }
            return u;
        }


        static internal User Register()
        {
            List<User> users = UserAndJson.ReadFromJson();
            string Name = "", Surname = "", Username = "", Password = "";
        Again:
            while (!Validation.UsernameValidation(Username))
            {
                Console.Write("Username: ");
                Username = Console.ReadLine();
            }
            if (Validation.IsContainUsername(Username))
            {
                Console.WriteLine(" !This username already taken");
                Username = "";
                goto Again;
            }
            while (!Validation.PasswordValidation(Password))
            {
                Console.Write("Password: ");
                Password = Console.ReadLine();
            }
            while (!Validation.NameValidation(Name))
            {
                Console.Write("Name: ");
                Name = Console.ReadLine();
            }
            while (!Validation.NameValidation(Surname))
            {
                Console.Write("Surname: ");
                Surname = Console.ReadLine();
            }

            User u = new User(Username, Password, Name, Surname);
            UserAndJson.AddToJson(u);

            Console.WriteLine($"Welcome, {u.Name} {u.Surname}");
            return u;
        }
    }
}
