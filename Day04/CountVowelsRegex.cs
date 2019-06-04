using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace HomeWork3
{
    class Problem3
    {
        static void Main(string[] args)
        {
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                // Sets up a Regex expression to search the input file and matches each vowel in it, ignoring case. 
                string input = sr.ReadToEnd();
                string pattern = @"[aeiou]";
                int numberOfVowels = Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count;

                // The vowel count is printed out and the program waits for the user to end the program. 
                Console.WriteLine($"Your input file contains {numberOfVowels} vowels.");
                Console.WriteLine("Press ENTER to continue:");
                Console.ReadLine();
            }
        }
    }
}
