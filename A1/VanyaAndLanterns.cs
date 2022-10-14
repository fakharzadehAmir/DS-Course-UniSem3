using System;
using System.Collections.Generic;
using static System.Int32;

namespace A1
{
    public static class VanyaAndLanterns
    {
        public static void Sorted( IList<double> lanterns, int sizeoflan)
        {
            for (var i = 1; i < sizeoflan ; i++)
            {
                var key = lanterns[i];
                var j = i - 1;
                while (j>=0 && lanterns[j]>key)
                {
                    lanterns[j + 1] = lanterns[j];
                    j--;
                }
                lanterns[j + 1] = key;
            }
        }
        public static double FindRadius(IReadOnlyList<double> placeOfLanterns, int sizeoflan, double maxLength)
        {
            var max = (placeOfLanterns[0]);
            for (var i = 1; i < sizeoflan; i++)
                max = (placeOfLanterns[i] - placeOfLanterns[i - 1]) / 2 > max
                    ? (placeOfLanterns[i] - placeOfLanterns[i - 1]) / 2 : max;
            return maxLength - placeOfLanterns[sizeoflan - 1] > max ? 
                maxLength - placeOfLanterns[sizeoflan - 1] : max;
            
        }
        // public static void Main(string[] args)
        // {
        //     var numOfLanternsAndStreetLegnth = Array.ConvertAll(Console.ReadLine()?.Split() ?? Array.Empty<string>(), double.Parse);
        //     var placeOfLanterns = Array.ConvertAll(Console.ReadLine()?.Split() ?? Array.Empty<string>(), double.Parse);
        //     Sorted(placeOfLanterns, (int)numOfLanternsAndStreetLegnth[0]);
        //     Console.WriteLine("{0:0.0000000000}",FindRadius(placeOfLanterns, (int)numOfLanternsAndStreetLegnth[0],numOfLanternsAndStreetLegnth[1]));
        // }
    }
}