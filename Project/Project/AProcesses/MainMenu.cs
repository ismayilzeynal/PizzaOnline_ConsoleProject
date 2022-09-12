using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Extensions;
using Project.CRUDs;

namespace Project.AProcesses
{
    static class MainMenu
    {

        public static void Menu(User u)
        {
            if (u.IsAdmin)
                AdminMenu(u, PrintForAdmin());
            else
                UserMenu(u, PrintForUser());
        }

        private static int PrintForUser()
        {
            int choise = -1;
            Console.Clear();
            Console.WriteLine("1) Show Pizzas \n2) Order \n0) Exit");
            AdditionalProcesses.TryInt(out choise);
            return choise;
        }

        public static int UserMenu(User u, int choise)
        {
        MenuLabel:
            // Console.Clear();
            switch (choise)
            {
                case 0:
                    AdditionalProcesses.Exit();
                    break;
                case 1:
                    ProductProcessing.ProductsMenu();
                    Menu(u);
                    break;
                case 2:
                    Order();
                    Menu(u);
                    break;
                case 3:
                    break;              // admində işlədəcəyik
                case 4:
                    break;              // admində işlədəcəyik
                default:
                    AdditionalProcesses.PEC();
                    goto MenuLabel;
            }
            return choise;
        }

        private static int PrintForAdmin()
        {
            int choise = -1;
            Console.Clear();
            Console.WriteLine("1) Show Pizzas \n2) Order \n3) Pizzas \n4) Users \n0) Exit");
            while (choise < 0 || choise > 4)
            {
                AdditionalProcesses.TryInt(out choise);
            }
            return choise;
        }

        public static void AdminMenu(User u, int choise)
        {
            int Adminchoise = UserMenu(u, choise);
            switch (Adminchoise)
            {
                case 3:
                    CRUDPizza.PizzaMenu();
                    break;
                case 4:
                    CRUDUser.UserMenu();
                    break;
                default:
                    Console.WriteLine("\n\nAnything gone wrong");
                    AdditionalProcesses.Exit();
                    break;
            }
        }



        public static void Order()
        {
            float sum = 0;
            List<Pizza> pizzas = CartProcessing.ReadFromJson();
            foreach (Pizza p in pizzas)
            {
                sum += (p.Count * p.Price);
            }
            if (sum != 0)
                Console.WriteLine($"{sum} AZN");
            else
            {
                if (EmptyCart() == 1)
                    return;
                else
                    AdditionalProcesses.Exit();
                return;
            }

        Again:
            Console.WriteLine("Contact number:");
            if (!ContainingSymbols.IsContactNumber(Console.ReadLine()))
            {
                AdditionalProcesses.PEC();
                goto Again;
            }
            Console.WriteLine("Adress:");
            // boşuna hansısa dəyişənə mənimsətmədimki onsuz üzərində iş görmürük. Yəni professional layihə olmadığına görə boşda qalacaq həmin dəyər zatən
            Console.ReadLine();

            Console.WriteLine("Your order has been registered");
            CartProcessing.ClearCart();
        }

        public static int EmptyCart()
        {
            Console.Clear();
            Console.WriteLine("Your cart is empty");
            Console.WriteLine("1) Back \n0) Exit");
            int choise = -1;
            while (choise < 0 || choise > 1)
            {
                AdditionalProcesses.TryInt(out choise);
            }
            return choise;
        }
    }
}
