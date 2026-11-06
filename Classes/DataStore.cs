using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;

namespace DataVerse_Manager.Classes
{
    public class DataStore<T> where T : BaseEntity
    {
        //Generisk klass som lagrar och sparar objekt i en JSON-fil
        private List<T> items = new List<T>();

        private string filepath;

        //Varje DataStore får veta vilken fil den hör till
        public DataStore(string filepath)
        {
            this.filepath = filepath;
        }

        public void AddItem(T item)
        {
            item.Id = GetNextId();
            items.Add(item);

        }

        // Hittar objektet med givet Id. Returnerar null om det inte finns
        public T? FindItem(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        // Tar bort objektet med givet Id. Returnerar false om det inte finns
        public bool RemoveItem(int Id)
        {
            T? found = FindItem(Id);

            if (found == null)
                return false;

            return items.Remove(found);
        }

        // Returnerar en kopia av listan så att ingen ändrar den utifrån
        public List<T> GetAll()
        {
            return new List<T>(items);
        }

        //Ger nästa lediga Id: högsta befintliga Id + 1, eller 1 om listan är tom
        private int GetNextId()
        {
            return items.Count == 0 ? 1 : items.Max(item => item.Id) + 1;
        }

        // Sparar listan till JSON-filen, fick Ai att göra den här
        public void SaveToJson()
        {
            try
            {
                string? folder = Path.GetDirectoryName(filepath);

                if (!string.IsNullOrEmpty(folder))
                    Directory.CreateDirectory(folder);

                string json = JsonSerializer.Serialize(
                    items,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(filepath, json);
                FailLogger.LogEvent($"Sparade {items.Count} objekt till {filepath}");
            }
            catch (Exception ex)
            {
                FailLogger.LogError(ex);
                AnsiConsole.MarkupLine($"[red]Kunde inte spara {Markup.Escape(filepath)}.[/]");
            }
        }
            // Läser listan från JSON-filen, fick ai att göra den här
             public void LoadFromJson()
        {
            try
            {
                string json = File.ReadAllText(filepath);
                items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                FailLogger.LogEvent($"Laddade {items.Count} objekt från {filepath}");
            }
            catch (FileNotFoundException ex)
            {
                FailLogger.LogError(ex);
                AnsiConsole.MarkupLine($"[red]Filen {Markup.Escape(filepath)} saknas. Startar med tom lista.[/]");
                items = new List<T>();
            }
            catch (DirectoryNotFoundException ex)
            {
                FailLogger.LogError(ex);
                AnsiConsole.MarkupLine($"[red]Mappen för {Markup.Escape(filepath)} saknas. Startar med tom lista.[/]");
                items = new List<T>();
            }
            catch (JsonException ex)
            {
                FailLogger.LogError(ex);
                AnsiConsole.MarkupLine($"[red]Filen {Markup.Escape(filepath)} är trasig. Startar med tom lista.[/]");
                items = new List<T>();
            }
        }
    }
}

