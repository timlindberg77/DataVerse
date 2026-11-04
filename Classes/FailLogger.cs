using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DataVerse_Manager.Classes
{
    public static class FailLogger
    {
        // -logPath : string
        private static string logPath = "log.json";

        // +LogEvent(string msg) : void
        public static void LogEvent(string msg)
        {
            Write($"HÄNDELSE | {msg}");
        }

        // +LogError(Exception ex) : void
        public static void LogError(Exception ex)
        {
            Write($"FEL | {ex.GetType().Name}: {ex.Message}");
        }

        // Hjälpmetod som skriver en rad till log.json
        private static void Write(string text)
        {
            try
            {
                var lines = new List<string>();

                if (File.Exists(logPath))
                {
                    string json = File.ReadAllText(logPath);
                    lines = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                }

                lines.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {text}");

                File.WriteAllText(logPath,
                    JsonSerializer.Serialize(lines, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch
            {
                // Loggern får aldrig krascha programmet
            }
        }
    }
}
