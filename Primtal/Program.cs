using System;

namespace Primtal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Primtal";
            Menu meny = new();
            meny.Start();
        }
    }
}