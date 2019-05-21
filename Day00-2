using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c)
    {
        int moveCount = 0;
        int bound = c.Length;
        for (int i = 0; i < bound; i++)
        {
            if (i + 1 > bound - 1)
            {
                break;
            }
            if (i + 2 > bound - 1)
            {
                moveCount++;
                break;
            }            
            if (c[i + 1] == 1)
            {
                i = i + 1;
                moveCount++;
            }
            else if (c[i + 1] == 0 && c[i + 2] == 0)
            {
                i = i + 1;
                moveCount++;
            }
            else if (c[i + 1] == 0 && c[i + 2] == 1)
            {
                moveCount++;
            }
        }
        return moveCount++;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
