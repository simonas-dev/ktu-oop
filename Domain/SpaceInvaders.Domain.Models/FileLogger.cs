using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceInvaders.Domain.Models
{
    public static class FileLogger
    {
        public static HashSet<string> Collection = new HashSet<string>();

        public static bool Exists = true;

        public static void Log(string message)
        {
            var path = $"{Directory.GetCurrentDirectory()}\\log.txt";

            if (Exists)
            {
                File.Delete(path);
                Exists = false;
            }

            if (Collection.Contains(message))
            {
                return;
            }

            File.AppendAllText(path, 
                $"[{DateTime.Now:yyyy-dd-M--HH-mm-ss}]: {message} {Environment.NewLine}");

            Collection.Add(message);
        }
    }
}