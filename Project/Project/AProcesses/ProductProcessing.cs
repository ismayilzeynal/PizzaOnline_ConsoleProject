using Project.Extensions;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.AProcesses
{
    static class ProductProcessing
    {
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

            foreach (string ingr in p.Ingridients)
                Console.WriteLine($"- {ingr}");

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
            }
            else if (Char.ToLower(choise) == 'g')
                return 0;
            else if (Char.ToLower(choise) == 'e')
                AdditionalProcesses.Exit();

            return 0;
        }



    }
}
