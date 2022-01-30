using System;
using System.Collections.Generic;
using System.Linq;
using shows.Models;

namespace shows
{
    class Program
    {
        static ShowsList shows = ShowsList.GetInstance();
        static void Main(string[] args)
        {
            int option;
            do
            {
                option = GetOption();
                switch (option)
                {
                    case 1:
                        Console.WriteLine(shows);
                        break;
                    case 2:
                        shows.Add(GetUserShow());
                        break;
                    case 3:
                        shows.Update(GetUserShow(true));
                        break;
                    case 4:
                        shows.Delete(GetUserId());
                        break;
                    case 5:
                        Console.WriteLine(shows.Read(GetUserId()));
                        break;
                }

                Console.Write("Continue...");
                Console.ReadKey();
            }
            while (option != 6);
        }
        static Guid GetUserId()
        {
            Console.Write("What is the show's id? ");
            return Guid.Parse(Console.ReadLine());
        }
        static int GetOption()
        {
            Console.Clear();
            Console.WriteLine("Welcome! What do you want to do today?");
            Console.WriteLine();
            Console.WriteLine("1 - List all the shows.");
            Console.WriteLine("2 - Insert a new show.");
            Console.WriteLine("3 - Update a show.");
            Console.WriteLine("4 - Delete a show.");
            Console.WriteLine("5 - Visualize a show.");
            Console.WriteLine("6 - Leave.");
            Console.WriteLine();
            Console.Write(">>> ");

            int option;

            while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out option) || !(1 <= option && option <= 6))
                Console.Write("\r>>> ");

            Console.WriteLine();

            return option;
        }
        static Show GetUserShow(bool hasId = false)
        {
            Guid id = Guid.Empty;

            if (hasId)
            {
                Console.Write("\nWhat is the show's id? ");
                id = Guid.Parse(Console.ReadLine());
            }

            Console.Write("\nWhat is the show's title? ");
            string title = Console.ReadLine();

            PrintGenres();
            Console.Write("From the list above, what are the show's genres? (Separated with ',') ");
            var genres = Console.ReadLine().Replace(" ", "").Split(',').Select(x => (Genre)int.Parse(x)).ToList();

            Console.Write("\nWhat is the synopsis? ");
            string synopsis = Console.ReadLine();

            Console.Write("\nWhat is the release year? ");
            ushort year = ushort.Parse(Console.ReadLine());

            if (hasId)
                return new Show(id, title, genres, synopsis, year);

            return new Show(title, genres, synopsis, year);

        }
        static void PrintGenres()
        {
            Console.WriteLine("\n1 Action       2 Drama           3 Comedy");
            Console.WriteLine("4 Sci-fi       5 Romance         6 Horror");
            Console.WriteLine("7 Thriller     8 Fantasy         9 Mystery");
            Console.WriteLine("10 Musical     11 Documentary");
        }
    }
}
