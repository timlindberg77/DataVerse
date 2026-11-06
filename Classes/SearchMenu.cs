using System;
using System.Collections.Generic;
using System.Text;

namespace DataVerse_Manager.Classes
{
    // Menyn för att lista och söka bland yrken
    public class SearchMenu : Menu
    {
        // Lagringen med alla yrken (delas med de andra menyerna)
        private DataStore<Occupation> Occupations;

        // Tar emot datan utifrån och sätter menyns titel
        public SearchMenu(DataStore<Occupation> occupations)
        {
            Occupations = occupations;
            Title = "Sök jobb";
        }

        // Visar undermenyn tills användaren går tillbaka
        public override void Show()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine(Title);
                Console.WriteLine();
                Console.WriteLine("1. Visa alla jobb");
                Console.WriteLine("2. Sök på namn");
                Console.WriteLine("3. Tillbaka");

                int selectedChoice = ReadChoice();

                switch (selectedChoice)
                {
                    case 1:
                        ListAllJobs();
                        break;
                    case 2:
                        SearchByName();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        ShowError("Ogiltigt val.");
                        break;
                }
            }
        }

        // Skriver ut alla yrken
        public void ListAllJobs()
        {
            Console.Clear();
            List<Occupation> all = Occupations.GetAll();

            if (all.Count == 0)
            {
                Console.WriteLine("Inga yrken hittades.");
            }
            else
            {
                foreach (Occupation occupation in all)
                {
                    Console.WriteLine($"{occupation.Name} ({occupation.Industry})");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        // Frågar efter ett namn och visar träffarna
        public void SearchByName()
        {
            Console.Clear();
            Console.Write("Ange yrke att söka efter: ");
            string name = Console.ReadLine() ?? string.Empty;

            List<Occupation> matches = FindByName(name);

            if (matches.Count == 0)
            {
                Console.WriteLine("Inga träffar.");
            }
            else
            {
                foreach (Occupation occupation in matches)
                {
                    Console.WriteLine($"{occupation.Name} ({occupation.Industry})");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        // Returnerar alla yrkens namn som innehåller texten (utan hänsyn till stora/små bokstäver)
        public List<Occupation> FindByName(string name)
        {
            return Occupations.GetAll()
                .Where(occupation => occupation.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
