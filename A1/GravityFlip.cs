using System;
using System.Collections.Generic;
using static System.Int32;

namespace A1
{
    public static class GravityFlip
    {
        private static IEnumerable<int> SortedGravity(int size, IList<int> boxes)
        {
            for (var i = 1; i < size ; i++)
            {
                var key = boxes[i];
                var j = i - 1;
                while (j>=0 && boxes[j]>key)
                {
                    boxes[j + 1] = boxes[j];
                    j--;
                }
                boxes[j + 1] = key;
            }
            return boxes;
        }
        // public static void Main(string[] args)
        // {
        //     var sizeOfColumn = Parse(Console.ReadLine() ?? string.Empty);
        //     var numOfBoxes = Array.ConvertAll(Console.ReadLine()?.Split() ?? Array.Empty<string>(), Parse);
        //     Console.WriteLine(string.Join(" ", SortedGravity(sizeOfColumn, numOfBoxes)));
        // }
    }
}