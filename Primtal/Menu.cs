using System;
using System.Collections.Generic;
using System.Linq;
using static Primtal.Helpers.InputValidation;


namespace Primtal
{
    public class Menu
    {
        //Jag valde att arbeta med en lista med den enkla anledningen att det 
        // räcker med en lista för detta programmet.
        private readonly List<int> primTal = new();
        PrimeNumbers pm = new();
        /// <summary>
        /// En enkel liten meny här har jag valt att jobba med en while loop som jag sätter till true
        /// och jag kommer ha felhantering av inputen i ett default case.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Hitta primtal\n2. Lista Primtal\n3. Lägg till nästa\n[e] för att avsluta");
                char choice = Console.ReadKey().KeyChar;
                switch (char.ToLower(choice))
                {
                    case '1':
                        SearchPrime();
                        break;
                    case '2':
                        PrintList();
                        break;
                    case '3':
                        AddNextPrime();
                        break;
                    case 'e':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning, försök igen");
                        break;
                }
            }
        }


        /// <summary>
        /// Kommer även här jobba med en while loop som kör tills man väljer att gå tillbaka till 
        /// huvudmenyn, denna metoden samt med hjälpmetoder kommer ta input från användaren, parsar strängen till integer
        /// om det lyckas skickar vi värdet till IsPrimeNumber som kontrollerar vare sig det är en primtal eller ej, 
        /// Om det är ett primatal kommer det kontrolleras om det redan finns i listan annars läggs det till i listan,
        /// Sedan kör vi om tills användaren känner sig nöjd. 
        /// </summary>
        private void SearchPrime()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("[e] för att återgå till menyn]\n\nAnge ett positivt heltal: ");
                var input = Console.ReadLine();

                if (input.ToLower() == "e") break;

                if (IsValidInput(input, out string errorMsg, out int validNum))
                {
                    if (pm.IsPrimeNumber(validNum))
                    {
                        IsNumberAdded(validNum);
                    }
                    else
                    {
                        Console.WriteLine($"{validNum} is not a prime");
                    }
                }
                Console.WriteLine(errorMsg);
                EnterKeyToContinue();
            }
        }

        /// <summary>
        /// Tar högsta numret från listan och adderar med 1 
        /// 
        /// </summary>
        public void AddNextPrime()
        {
            Console.Clear();
            int highestNumber = 1;
            if (IsListEmpty())
            {
                primTal.Sort();
                highestNumber = primTal.Last();
            }

            bool found = false;
            while (!found && highestNumber != int.MaxValue)
            {
                highestNumber++;
                if (pm.IsPrimeNumber(highestNumber))
                {
                    IsNumberAdded(highestNumber);
                    found = true;
                }
            }
            Console.WriteLine(highestNumber == int.MaxValue ? $"max value nådd, jag jobbar inte med tal större än {int.MaxValue}" : "");
            EnterKeyToContinue();
        }


        /// <summary>
        /// Skriver ut listan till konsolen
        /// </summary>
        private void PrintList()
        {
            Console.Clear();
            Console.WriteLine(IsListEmpty() ? string.Join(" ,", primTal) : "Listan är tom, lägg till några nummer tack");
            EnterKeyToContinue();
        }


        /// <summary>
        /// Kollar om numret finns i listan, inte ett krav men why not liksom
        /// </summary>
        /// <param name="num">primtal</param>
        private void IsNumberAdded(int primeNumber)
        {
            if (primTal.Contains(primeNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{primeNumber} är ett primtal men fanns redan i listan");
                Console.ResetColor();
            }
            else
            {
                primTal.Add(primeNumber);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{primeNumber} Är ett primtal och har nu lagts till i listan");
                Console.ResetColor();
            }
        }

        private bool IsListEmpty()
        {
            return primTal.Any();
        }
    }
}
