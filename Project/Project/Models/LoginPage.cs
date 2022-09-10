using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Project.Extensions;
namespace Project.Models
{
    static class LoginPage
    {
        static string UserPath = "C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json";
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
            User u = null;
            int choise = -1;
            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();

            if (Authentication.AuthUser(Username, Password)) //Validation.PasswordValidation(Password) && Validation.NameValidation(Username) && 
            {
                List<User> users = new List<User>();
                using (StreamReader sr = new StreamReader(UserPath))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                }
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
                    u=Register();
            }
            return u;
        }


        static internal User Register()
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(UserPath))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            //File.Create("C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json").Close();
            string Name = "";
            string Surname = "";
            string Username = "";
            string Password = "";
            while (!Validation.UsernameValidation(Username))
            {
                Console.Clear();
                Console.Write("Username: ");
                Username = Console.ReadLine();
            }
            while (!Validation.PasswordValidation(Password))
            {
                Console.Clear();
                Console.Write("Password: ");
                Password = Console.ReadLine();
            }
            while (!Validation.NameValidation(Name))
            {
                Console.Clear();
                Console.Write("Name: ");
                Name = Console.ReadLine();
            }
            while (!Validation.NameValidation(Surname))
            {
                Console.Clear();
                Console.Write("Surname: ");
                Surname = Console.ReadLine();
            }

            User u = new User(Username, Password, Name, Surname);
            users.Add(u);

            using (StreamWriter sw = new StreamWriter("C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }

            Console.WriteLine($"Welcome, {u.Name} {u.Surname}");
            return u;
        }





    }
}
