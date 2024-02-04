using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal class UserInterface
    {
        private static int _menuItems = 3;
        private static string _author = "Jakub Jelinek";
        public static void ShowMenu()
        {
            Console.WriteLine("=============");
            Console.WriteLine("     Menu    ");
            Console.WriteLine("=============");

            Console.WriteLine($"1: Hrát");
            Console.WriteLine($"2: Autor");
            Console.WriteLine($"3: Ukončit");

            Console.WriteLine("=============");
        }

        public static int GetMenuChoice()
        {
            int choice;
            do
            {
                Console.Write($"\nZadej svůj výběr (1-{_menuItems}): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _menuItems);

            return choice;
        }

        public static void ShowMessage(string message, bool clear = true)
        {
            if (clear)
            {
                Console.Clear();
            }
            Console.WriteLine(message);
            Console.WriteLine("Pokračuj ENTER ...");
            Console.ReadLine();
            if (clear)
            {
                Console.Clear();
            }
        }

        public static void ShowAuthor()
        {
            ShowMessage(_author);
        }
    }
}
