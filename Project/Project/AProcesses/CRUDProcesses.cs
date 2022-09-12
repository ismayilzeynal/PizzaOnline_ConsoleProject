using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Project.Extensions;
using Project.Models;
namespace Project.AProcesses
{
    static class CRUDProcesses
    {
        public static Pizza EditPizza()
        {
            int choise;
            Pizza p = ProductProcessing.FindPizzaById();
            DeletePizza(p);
        EditPizzaLabel:
            Console.WriteLine("What you want to edit: ");
            Console.WriteLine("1) Name \n2) Price \n3) Ingridients 0) Back");
            AdditionalProcesses.TryInt(out choise);

            switch (choise)
            {
                case 1:
                    p.Name = ProductProcessing.EditName();
                    break;
                case 2:
                    p.Price = ProductProcessing.EditPrice();
                    break;
                case 3:
                    p.Ingridients = ProductProcessing.EditIngridients();
                    break;
                case 0:
                    break;
                default:
                    goto EditPizzaLabel;
            }
            return p;
        }

        public static void DeletePizza(Pizza p)
        {
            List<Pizza> pizzas = PizzasAndJson.ReadFromJson();
            List<Pizza> pizzas2 = new List<Pizza>();
            foreach (Pizza piz in pizzas)
            {
                if (p.Name != piz.Name)
                    pizzas2.Add(piz);
            }
            using (StreamWriter sw = new StreamWriter("C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(pizzas2));
            }
        }



        public static Pizza CreatePizza()
        {
            string PizzaName;
            float PizzaPrice;
            List<string> PizzaIngridients = new List<string>();
        Again:
            PizzaName = ProductProcessing.EditName();
            if (Validation.IsContainPizza(PizzaName))
            {
                Console.WriteLine(" !This pizza already created");
                PizzaName = "";
                goto Again;
            }
            PizzaPrice = ProductProcessing.EditPrice();

            PizzaIngridients = ProductProcessing.EditIngridients();

            Pizza p = new Pizza(PizzaName, PizzaPrice, PizzaIngridients);
            return p;
        }

        public static Pizza CreateUser()
        {
            string PizzaName;
            float PizzaPrice;
            List<string> PizzaIngridients = new List<string>();

            PizzaName = ProductProcessing.EditName();

            PizzaPrice = ProductProcessing.EditPrice();

            PizzaIngridients = ProductProcessing.EditIngridients();

            Pizza p = new Pizza(PizzaName, PizzaPrice, PizzaIngridients);
            return p;
        }

        public static User EditUser()
        {
            User u = FindUserById();
            DeleteUser(u);
            if (!u.IsAdmin)
                u.IsAdmin = true;
            return u;
        }

        public static User FindUserById()     // input ID in here
        {
            List<User> users = UserAndJson.ReadFromJson();
            int choise;
            do
            {
                AdditionalProcesses.TryInt(out choise);
            } while (!users.Exists(p => p.Id == choise));

            User user = users.Find(u => u.Id == choise);
            return user;
        }


        public static void DeleteUser(User u)
        {
            List<User> users = UserAndJson.ReadFromJson();
            List<User> users2 = new List<User>();
            foreach (User us in users)
            {
                if (u.Username != us.Username)
                    users2.Add(us);
            }
            using (StreamWriter sw = new StreamWriter("C:\\Users\\asus\\OneDrive\\Desktop\\Code Academy\\Console Project\\Project\\Project\\Files\\Users.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users2));
            }
        }
    }
}
