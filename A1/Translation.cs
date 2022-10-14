using System;

namespace A1
{
    public static class Translation
    {
        private static string CheckReverse(string sword, string tword)
        {
            int size = sword.Length - 1, num = 0;
            foreach (var w in tword)
            {
                if (w == sword[size]) { size--; num++; }
                else { break; }                
            }
            return num == sword.Length ? "YES" : "NO";
        }
        // public static void Main(string[] args)
        // {
        //     var sWord = Console.ReadLine();
        //     var tWord = Console.ReadLine();
        //     Console.WriteLine(CheckReverse(sWord,tWord));
        // }
    }
}