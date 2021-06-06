using System;
using System.Text.RegularExpressions;

namespace RegexValidators
{
    class Program
    {
        static void Main(string[] args)
        {
            if (validateEmail("jose@ejemplo.com"))
            {
                Console.WriteLine("Correo Valido!");
            }


            Console.WriteLine(getCCType("4169773331987017")); // https://www.getcreditcardnumbers.com/
            Console.WriteLine(getCCType("5410710000901089"));
            Console.WriteLine(getCCType("349101032764066"));


            if (validateCedula("001-1234567-8"))
            {
                Console.WriteLine("Cedula Valida!");
            }

            if (validateAmount("10,025.25"))
            {
                Console.WriteLine("Amount valid!");
            }


        }

        static bool validateCedula(string cedula)
        {
            Regex r = new Regex(@"^?([0-9]{3})[-.●]?([0-9]{7})[-.●]?([0-9]{1})$");
            return r.IsMatch(cedula) ? true : false;
        }

        static bool validateAmount(string amount)
        {
            Regex r = new Regex(@"^[\d\.,]*$"); // Check for better aproach
            return r.IsMatch(amount) ? true : false;
        }

        static string getCCType(string number)
        {

            if(Regex.Match(number, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
            {
                return "Visa";
            }

            if (Regex.Match(number, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
            {
                return "MasterCard";
            }

            if (Regex.Match(number, @"^3[47][0-9]{13}$").Success)
            {
                return "American Express";
            }

            throw new Exception("Unknown card.");
        }


        static bool validateEmail(string email)
        {
            Regex r = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$");
            return r.IsMatch(email) ? true : false;
        }
    }
}
