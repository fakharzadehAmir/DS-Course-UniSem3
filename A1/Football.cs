using System;

namespace A1
{
    internal static class Football
    {
        private static string CheckString(string number)
        {
            var situation = 0;
            for (var i = 1; i < number.Length && situation != 6; i++)
            {
                if (number[i] == number[i - 1])
                    situation += 1;
                else
                    situation = 0;
            }
            return situation == 6 ? "YES" : "NO";
        }
        // public static void Main(string[] args)
        // {
        //     var num = Console.ReadLine();
        //     Console.WriteLine(CheckString(num));
        // }
    }
}
