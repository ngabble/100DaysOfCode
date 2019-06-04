using System;
using System.Linq;

namespace Homework
{
    class Problem1
    {
        // We start with a list of the characters we want to capture.
        // Alternatively we could convert the input to lower case and halve this list. 
        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        static void Main(string[] args)
        {
            // Prompt the user for input and feed that string into our CountVowels() method.
            Console.WriteLine("Type a sentence and I'll count it's vowels:");
            string input = Console.ReadLine();
            int vowelCount = CountVowels(input);
            // The number of vowels is returned and plugged into our interpolated sentence. 
            Console.WriteLine($"Your sentence has {vowelCount} vowels in it.");
        }
        protected static int CountVowels(string s)
        {
            // We take the string input by the user and compare each character to our list of vowels.
            // If we find a match we increment count.
            // Once we check each character we return out total.
            int count = 0;
            foreach (char c in s)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
