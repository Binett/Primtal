using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primtal
{
    class PrimeNumbers
    {
        public bool IsPrimeNumber(int number)
        {
            if (number <= 1) return false; //allt under 2 är inte primtal
            if (number != 2) // låter 2 returnera true direkt då det är det lägsta primtalet, således behöver inte det kontrolleras
            {
                if (number % 2 == 0) return false; // eftersom alla jämna tal är delbara med 2 kan man utesluta jämna tal

                // i loopen kontrollerar jag delbarheten mot alla tal som är mindre än kvadratroten av number(input från användaren)
                // looppen kommer därför köras så länge indexet som nu har ett startvärde av 3, är mindre än kvadratroten av number
                // dvs om vi tar tex number = 97 kvadratroten ur 97 ~ 9.84 alltså räcker det med att kontrollera om 97 går att dela med
                // något tal under i detta fallet blir det 9 eftersom vi redan uteslutit jämna tal över 2. första itterationen i loopen
                // kollar vi 97%3 = 1 i rest, andra itterationen 97%5 = 2 i rest, tredje itterationen 97%7 = 6 i rest och där har vi gått igenom
                // och kollat om de primtalen som är lägre än kvadratroten ur number.

                for (int i = 3; i <= Math.Sqrt(number); i += 2)
                {

                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
