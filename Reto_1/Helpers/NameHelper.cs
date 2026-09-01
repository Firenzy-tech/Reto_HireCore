using System;

namespace HireCore.ConsoleApp.Helpers
{
    public static class NameHelper
    {
        private static readonly string[] Names = { "Ana", "Carlos", "Elena", "David", "Sofía" };
        private static readonly Random Rnd = new();

        public static string GetRandom()

        {
            int indice = Rnd.Next(Names.Length);
            return Names[indice];
        }

    }
}