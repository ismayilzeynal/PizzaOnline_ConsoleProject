using System;
using System.Collections.Generic;
using System.Text;
using Project.AProcesses;
using Project.Extensions;
using Project.Models;

namespace Project.CRUDs
{
    static class CRUDPizza
    {
        public static void PizzaMenu()
        {
        PizzaMenuLabel:
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
                    goto PizzaMenuLabel;
            }

            choise = -1;
            Console.WriteLine("1) Back 0) Exit");
            while(choise<0 || choise>1)
                AdditionalProcesses.TryInt(out choise);
            if (choise == 0)
                AdditionalProcesses.Exit();
            else
                goto PizzaMenuLabel;

        }


        public static void Read()
        {
            List<Pizza> pizzas;
            pizzas = PizzasAndJson.ReadFromJson();
            if(pizzas!=null)
                foreach (Pizza p in pizzas)
                {
                    p.Print();
                    Console.WriteLine("\n");
                }
            else
                Console.WriteLine("Pizzas is empty");
        }

        public static void Create()
        {
            PizzasAndJson.AddToJson(CRUDProcesses.CreatePizza());
            Console.WriteLine("Pizza added");
        }

        public static void Update()
        {
            // Console.Clear();
            Console.WriteLine("Input ID: \n");
            Read();
            PizzasAndJson.AddToJson(CRUDProcesses.EditPizza());
            Console.WriteLine("Pizza edited");
        }

        public static void Delete()
        {
            Console.WriteLine("Input ID: \n");
            Read();
            CRUDProcesses.DeletePizza(ProductProcessing.FindPizzaById());
            Console.WriteLine("Pizza deleted");
        }





    }
}
