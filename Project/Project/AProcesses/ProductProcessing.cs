using Project.Extensions;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.AProcesses
{
    static class ProductProcessing
    {

        public static Pizza FindPizzaById()     // input ID in here
        {
            List<Pizza> pizzas = PizzasAndJson.ReadFromJson();
            int choise;
            do
            {
                AdditionalProcesses.TryInt(out choise);
            } while (!pizzas.Exists(p => p.Id == choise));

            Pizza pizza = pizzas.Find(p => p.Id == choise);
            return pizza;
        }

        public static string EditName()
        {
            string PizzaName;
            Console.WriteLine("Name: ");
            do
            {
                PizzaName = Console.ReadLine();
            } while (!Validation.NameValidation(PizzaName));

            return PizzaName;
        }

        public static float EditPrice()
        {
            float PizzaPrice;
            Console.WriteLine("Price: ");
            AdditionalProcesses.TryFloat(out PizzaPrice);
            return PizzaPrice;
        }

        public static List<string> EditIngridients()
        {
            int IngridientCount;
            List<string> PizzaIngridients = new List<string>();
            Console.WriteLine("Cont of Ingridients");
            AdditionalProcesses.TryInt(out IngridientCount);

            
            for (int i = 0; i < IngridientCount; i++)
            {
                Console.WriteLine($"Ingridient {i+1}: ");
                string Ingridient;
                do
                {
                    Ingridient = Console.ReadLine();
                } while (!Validation.NameValidation(Ingridient));
                PizzaIngridients.Add(Ingridient);
            }
            return PizzaIngridients;
        }

        public static void PrintPizzas()
        {
            List<Pizza> pizzas = PizzasAndJson.ReadFromJson();
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine($"- {pizza.Id}. {pizza.Name}");
            }
        }


        public static void ProductsMenu()
        {
            List<Pizza> pizzas = PizzasAndJson.ReadFromJson();
            int choise = -1;
            Pizza p;
            Console.Clear();
            Console.WriteLine("Input ID: \n");
            PrintPizzas();
        InputIdLabel:
            AdditionalProcesses.TryInt(out choise);
            try
            {
                p = pizzas.Find(p => p.Id == choise);
            }
            catch (Exception)
            {
                Console.WriteLine("Abnormal input");
                goto InputIdLabel;
            }
            PrintIngridients(p);
        }


        public static int PrintIngridients(Pizza p)
        {
        IngridientsLabel:
            char choise = '-';
            int count;
            Console.Clear();
            Console.WriteLine("S) Add to cart \nG) Back \nE) Exit \n");

            if(p!=null)
            foreach (string ingr in p.Ingridients)
                Console.WriteLine($"- {ingr}");
            else
                Console.WriteLine("p is null");
            try
            {
                choise = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception)
            {
                AdditionalProcesses.PEC();
                goto IngridientsLabel;
            }

            if (Char.ToLower(choise) == 's')
            {
                Console.WriteLine("Enter count: ");
                AdditionalProcesses.TryInt(out count);
                CartProcessing.AddToJson(p, count);
                //---------------

            }
            else if (Char.ToLower(choise) == 'g')
                return 0;
            else if (Char.ToLower(choise) == 'e')
                AdditionalProcesses.Exit();
            return 0;
        }

        
    }
}
