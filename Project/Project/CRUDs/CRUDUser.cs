using Project.AProcesses;
using Project.Extensions;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.CRUDs
{
    static class CRUDUser
    {
        public static void UserMenu()
        {
        UserMenuLabel:
            // Console.Clear();
            AdditionalProcesses.PrintCRUD();
            int choise = -1;
            AdditionalProcesses.TryInt(out choise);

            switch (choise)
            {
                case 0:
                    AdditionalProcesses.Exit();
                    break;
                case 1:
                    Read();
                    break;
                case 2:
                    Create();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                default:
                    AdditionalProcesses.PEC();
                    goto UserMenuLabel;
            }
            choise = -1;
            Console.WriteLine("1) Back 0) Exit");
            while (choise < 0 || choise > 1)
                AdditionalProcesses.TryInt(out choise);
            if (choise == 0)
                AdditionalProcesses.Exit();
            else
                goto UserMenuLabel;
        }


        public static void Read()
        {
            List<User> users;
            users = UserAndJson.ReadFromJson();
            foreach (User u in users)
            {
                u.Print();
                Console.WriteLine("\n");
            }
        }

        public static void Create()
        {
            UserAndJson.AddToJson(LoginPage.Register());  
            Console.WriteLine("User created");
        }

        public static void Update()
        {
            // Console.Clear();
            Console.WriteLine("Input ID for edit role: \n");
            Read();
            UserAndJson.AddToJson(CRUDProcesses.EditUser());
            Console.WriteLine("User role edited");
        }

        public static void Delete()
        {
            Console.WriteLine("Input ID: \n");
            Read();
            CRUDProcesses.DeleteUser(CRUDProcesses.FindUserById());
            Console.WriteLine("User deleted");
        }

    }
}
