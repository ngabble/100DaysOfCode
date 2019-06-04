using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Problem2
    {
        static void Main()
        {
            // We validate our input, test to see if it's divisible by three, and print the results. 
            int number = GetInput();
            bool result = Test(number);
            Console.WriteLine(Output(result, number));
        }
        private static int GetInput()
        {
            // We first declare our variables outside of our loop.
            // Then we ask for input.
            bool success = false;
            int input = 0;
            Console.WriteLine("Please enter an integer greater than 0:");
            while (true)
            {
                // TryParse() takes the input and attempts to turn it into an int.
                // If it succeeds our bool success is changed to true and input is changed to the users input.
                // If it fails we'll give the user some examples of correct inputs and prompt them to try again.
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (!success)
                {
                    Console.WriteLine("Integers are whole numbers like 1, 2, and 3. Please try again:");
                    continue;
                }
                // If the user tries to put in an int less than 0 we'll ask them to try again.
                else if (input < 0)
                {
                    Console.WriteLine("Your input should be greater than 0, Please try again:");
                    continue;
                }
                // once they get it right we return the validated input to Main().
                else
                {
                    return input;
                }
            }
        }
        private static bool Test(int n)
        {
            // A simple test using the remainder operator tells us if the int is divisible by 3 and returns a true or false.
            bool result = false;
            if (n % 3 == 0)
            {
                result = true;
            }
            return result;
        }
        private static string Output(bool result, int number)
        {
            // Here we choose the string to print based on the results for Test().
            string answer;
            if (result == true)
            {
                answer = $"Congratulations, {number} is divisible by 3!";
            }
            else
            {
                answer = $"Sorry, {number} is not divisible by 3.";
            }
            return answer;
        }
    }
}
