namespace RegexAlgorithms
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            bool isValid = false;
            string result = string.Empty;

            Console.WriteLine("What data would you like to validate?\n\n");
            Console.WriteLine(" 1: Email address");
            Console.WriteLine(" 2: Telephone number");
            Console.WriteLine(" 3: Web address\n\n Make your selection.");
            input = Console.ReadLine();

            if (input == "1")
            {
                input = string.Empty;
                Console.WriteLine("Enter email address?");
                input = Console.ReadLine();
                isValid = EmailRegex(input);
                result = ConvertBooleanToString(isValid);
                Console.WriteLine("Email address is " + result);
            }
            else if (input == "2")
            {
                input = string.Empty;
                Console.WriteLine("Enter telephone number?");
                input = Console.ReadLine();
                isValid = TelephoneRegex(input);
                result = ConvertBooleanToString(isValid);
                Console.WriteLine("Telephone number is " + result);
            }
            else if (input == "3")
            {
                input = string.Empty;
                Console.WriteLine("Enter web address?");
                input = Console.ReadLine();
                isValid = WebAddressRegex(input);
                result = ConvertBooleanToString(isValid);
                Console.WriteLine("Web address is " + result);
            }
        }

        public static bool EmailRegex(string email)
        {
            string regexPattern = @"^([a-zA-Z0-9-.])*@([a-zA-Z0-9])*\.[a-zA-Z]*$";
            return Regex.IsMatch(email, regexPattern, RegexOptions.IgnoreCase);
        }

        /*
         * Assumptions: every number starts with a 0,
         * preceeding number - esp. in South Africa, can never be a 0 
         * e.g. 001 325 0039 but will be 010 325 0039 or 073 325 0039
         * There will always be 10 characters if country code is not included
         */
        public static bool TelephoneRegex(string telephoneNumber)
        {
            string regexPattern = @"^[0]([1-9]{2})?([0-9]{3})?([0-9]{4})$";
            return Regex.IsMatch(telephoneNumber, regexPattern, RegexOptions.IgnoreCase);
        }

        public static bool WebAddressRegex(string webAddress)
        {
            string regexPattern = @"[a-zA-Z0-9-]*\.[a-zA-Z0-9]*\.[a-zA-Z]*$";
            return Regex.IsMatch(webAddress, regexPattern, RegexOptions.IgnoreCase);
        }

        public static string ConvertBooleanToString(bool input)
        {
            return input == true ? "valid" : "invalid";
        }
    }
}

