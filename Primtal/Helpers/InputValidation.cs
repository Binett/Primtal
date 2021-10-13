using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primtal.Helpers
{
    public static class InputValidation
    {
        /// <summary>
        /// Kontrollerar input från användaren
        /// </summary>
        /// <param name="input">input från användaren</param>
        /// <param name="errorMsg">sätter olika errorMsg som kan skrivas ut till konsolen</param>
        /// <param name="validNum">parsat värde</param>
        /// <returns></returns>
        public static bool IsValidInput(string input, out string errorMsg, out int validNum)
        {
            errorMsg = "";
            if (IsNumber(input, out validNum)) //Försöker casta input till int
            {
                if (validNum <= 0) // om casting lyckas men värdet är negativt
                {
                    errorMsg = $"\nPositiva tal säger instruktionerna, du har angett {input}, vilket inte är ett positivt tal större än 0 försök igen";
                    return false;
                }
                return true;
            }
            //om castingen inte lyckats ändra errorMsg och returnera false
            errorMsg = "Du har inte angett ett giltigt tal, försök igen";
            return false;
        }

        private static bool IsNumber(string input, out int validNum)
        {
            return int.TryParse(input, out validNum);
        }

        /// <summary>
        /// Hjälpmetod för att stanna upp och reflektera lite 
        /// </summary>
        public static void EnterKeyToContinue()
        {
            Console.WriteLine("[valfri tangent för att fortsätta]");
            Console.ReadKey();
        }
    }
}
