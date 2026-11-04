using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Spectre.Console;

namespace DataVerse_Manager.Classes
    {
        public class MainMenu
        {
            // Bool som styr om menyn ska köras eller inte
            private bool RunMenu = true;

            // Kör menyn tills användaren avslutar
            public void MainMenuMethod()
            {
                while (RunMenu)
                {
                    ClearConsole();
                    SpectreBannerMenu();

                    // Läser in valet, kraschar inte om det inte är ett tal
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Ogiltigt val, ange ett nummer. Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            // All statistics (AllStatisticsMenu)
                            break;
                        case 2:
                            // Filter statistics (FilterMenu)
                            break;
                        case 3:
                            // Search jobs (SearchMenu)
                            break;
                        case 4:
                            // Job compass (CompassMenu)
                            break;
                        case 5:
                            // Application manager (ApplicationManagerMenu)
                            break;
                        case 6:
                            Console.WriteLine("Avslutar programmet...");
                            RunMenu = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Tryck på valfri tangent...");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            // Skriver ut banner och menyalternativ
            public void SpectreBannerMenu()
            {
                AnsiConsole.Write(new FigletText("DataVerse").Color(Color.Cyan1));
                AnsiConsole.MarkupLine("[bold]Huvudmeny[/]");
                Console.WriteLine();
                Console.WriteLine("1. All statistics");
                Console.WriteLine("2. Filter statistics");
                Console.WriteLine("3. Search jobs");
                Console.WriteLine("4. Job compass");
                Console.WriteLine("5. Application manager");
                Console.WriteLine("6. Avsluta programmet");
                Console.WriteLine();
                Console.Write("Välj ett alternativ: ");
            }

            // Rensar skärmen
            public void ClearConsole()
            {
                Console.Clear();
            }
        }
    }


