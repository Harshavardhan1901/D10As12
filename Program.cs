using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a piece of text: ");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            Console.WriteLine($"Word Count: {wordCount}");

            var emailAddresses = ExtractEmailAddresses(inputText);
            Console.WriteLine("Email Addresses:");
            foreach (var email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            var mobileNumbers = ExtractMobileNumbers(inputText);
            Console.WriteLine("Mobile Numbers:");
            foreach (var mobileNumber in mobileNumbers)
            {
                Console.WriteLine(mobileNumber);
            }

            Console.Write("Enter a custom regular expression: ");
            string customRegex = Console.ReadLine();

            var customMatches = PerformCustomRegexSearch(inputText, customRegex);
            Console.WriteLine("Custom Regex Search Results:");
            foreach (Match match in customMatches)
            {
                Console.WriteLine(match.Value);
            }
            Console.ReadKey();
        }

        static int CountWords(string text)
        {
            // Regular expression to match words (sequences of characters separated by spaces)
            string wordPattern = @"\b\w+\b";

            int wordCount = Regex.Matches(text, wordPattern).Count;
            return wordCount;
        }

        static string[] ExtractEmailAddresses(string text)
        {
            // Regular expression to match email addresses
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

            var matches = Regex.Matches(text, emailPattern, RegexOptions.IgnoreCase);

            string[] emailAddresses = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                emailAddresses[i] = matches[i].Value;
            }

            return emailAddresses;
        }

        static string[] ExtractMobileNumbers(string text)
        {
            // Regular expression to match mobile numbers (assuming a 10-digit format)
            string mobileNumberPattern = @"\b\d{10}\b";

            var matches = Regex.Matches(text, mobileNumberPattern);

            string[] mobileNumbers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                mobileNumbers[i] = matches[i].Value;
            }

            return mobileNumbers;
        }

        static MatchCollection PerformCustomRegexSearch(string text, string customRegex)
        {
            // Perform custom regex search using the provided regex pattern
            var matches = Regex.Matches(text, customRegex);
            return matches;
        }
    }
}
