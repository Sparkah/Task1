using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Создаем два листа, инвентарь и стол
            List<string> tableElements = new List<string>();
            List<string> inventory = new List<string>();

            for (int i = 0; i<33;i++)
            {
                tableElements.Add("Coin");
            }
            tableElements.Add("Amulet");
            tableElements.Add("Book");
            AtTheTable(tableElements, inventory);
        }

        static void AtTheTable(List<string> tableElements, List<string> inventory)
        {
            DrawTable(tableElements, inventory);
        }

        //смотрим что остается на столе после того как что-то оттуда забираем
        static void DrawTable(List<string> tableElements, List<string> inventory)
        {
           for (int i = 0; i<tableElements.ToArray().Length;i++)
            {
                Console.Write(tableElements[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("___");
            Console.WriteLine("Type the element you want to pick or type Cancel to leave the table");
            PickFromTable(tableElements, inventory);
        }

        //забираем вещь со стола
        static void PickFromTable(List<string> tableElements, List<string> inventory)
        {
            string x =Console.ReadLine();

            if (x == "Coin" || x == "Amulet" || x == "Book")
            {
                Console.WriteLine(x + "Picked");
                inventory.Add(x);
                tableElements.Remove(x);
                DrawTable(tableElements, inventory);
            }
            // проверка что в инвентарь падают вещи собранные со стола
            if(x=="2")
            {
                for (int i = 0; i < inventory.ToArray().Length; i++)
                {
                    Console.Write(inventory[i] + " ");
                }
            }
            if(x=="Cancel")
            {
                LookAroundRoom(tableElements, inventory);
            }

            else
            {
                Console.WriteLine("Try again");
                PickFromTable(tableElements, inventory);
            }
        }

        //Отойти от стола
        static void LookAroundRoom(List<string> tableElements, List<string> inventory)
        {
            Console.WriteLine("Press x to view table");
            if(Console.ReadKey().Key==ConsoleKey.X)
            {
                AtTheTable(tableElements, inventory);
            }
            else
            {
                LookAroundRoom(tableElements, inventory);
            }
        }
    }
}
