using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace DataVerse_Manager.Classes
{
    public abstract class Menu
    {
        protected string Title { get; set; } = ""; //används som rubrik för menyerna.

        public abstract void Show(); //Metod som ska användas för spctre animationer i meny alternativen med override
        

        protected int ReadChoice()
        {
            try
            {
                string input = Console.ReadLine()!; 
                return int.Parse(input!); //tar inpput och omformaterar till en int, om det inte är en siffra fångar catch det.
            }
            catch (FormatException) //Fångar ifall input inte är en siffra
            {
                ShowError("Skriv en siffra");
                return -1;
            }
            catch (ArgumentNullException) //fångar ifall Input från användaren är tomt
            {
                ShowError("Får inte vara tomt");
                return -1;
            }
        }

        protected void ShowError(string msg) 
        {
            AnsiConsole.Markup($"[red]Fel: {Markup.Escape(msg)}[/]"); //Använder Spctre för att skriva felmeddelandet i rött i terminalen.
        }
    }
}
