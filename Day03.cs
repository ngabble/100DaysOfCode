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

class Solution {


static int[] rotLeft(int[] a, int n) {
    //n %= a.Length;
    var ret = new int[a.Length];
    for(int i = 0; i < a.Length; ++i) {
        ret[i] = a[(i + n) % a.Length];
    }
    return ret;
}
    // The below solution works but times out at large n values.
    /*static int[] rotLeft(int[] a, int d) {
        int temp;
        for (int i = 1; i <= d; i++)
        {
            for (int j = 0; j < a.Length - 1; j++)
            {
                temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }
        }
        return a;
    }*/

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] result = rotLeft(a, d);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
