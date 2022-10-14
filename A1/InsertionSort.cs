using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
namespace A1
{
    public static class Queries
    {
        public static IEnumerable<int> Sort(int[] array, bool @descending = false)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;
                switch (@descending)
                {
                    case false:
                    {
                        while (j >= 0 && array[j] > key)
                        {
                            array[j + 1] = array[j];
                            j--;
                        }
                        break;
                    }
                    default:
                    {
                        while (j >= 0 && array[j] < key)
                        {
                            array[j + 1] = array[j];
                            j--;
                        }
                        break;
                    }
                }
                array[j + 1] = key;
            }
            return array;
        }
        public static bool Is_Sorted(int[] array, bool descending = false)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;
                switch (@descending)
                {
                    case false:
                    {
                        if (array[j] < key)
                        {
                            return false;
                        }
                        break;
                    }
                    default:
                    {
                        if (array[j] > key)
                        {
                            return false;
                        }
                        break;
                    }
                }
            }
            return true;
        }
        public static int GetMax(int[] array)
        {
            var max = array[0];
            foreach (var a in array)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            return max;
        }
        public static int GetMin(int[] array)
        {
            var min = array[0];
            foreach (var a in array)
            {
                if (a < min)
                {
                    min = a;
                }
            }
            return min;
        }
        public static IEnumerable<int> AppendSorted(int[] array, int newNum)
        {
            var idx = 0;
            for (var i = 0; i<array.Length && array[i]<newNum ; i++)
            {
                idx = i;
                yield return array[i];
            }
            if (array[idx] < newNum)
            {
                yield return newNum;
                for (var i = idx+1; i<array.Length ; i++)
                {
                    yield return array[i];
                }
            }
            else if(array[idx] > newNum)
            {
                yield return newNum;
                for (var i = idx; i<array.Length ; i++)
                {
                    yield return array[i];
                }
            }
        }
        public static IEnumerable<int> GetHistogram(int[] array, double bins)
        {
            var start = (double)GetMin(array);
            var interval_legnth = Math.Ceiling((GetMax(array) - GetMin(array)) / bins);
            for (var i = 0; i < bins; i++)
            {
                var num = 0;
                foreach (var a in array)
                {
                    if (start <= a && a < start + interval_legnth)
                    {
                        num++;
                    }
                    else if( Math.Abs(i - (bins - 1)) < 1 && (start <= a && a <= start + interval_legnth))
                    {
                        num++;
                    }
                }
                start += interval_legnth;
                yield return num;
            }
            
        }
    }
    public static class InsertionSort
    {
        public static void Main(string[] args)
        {
            var numOfqueries = int.Parse(Console.ReadLine() ?? string.Empty);
            for (var i = 0; i < numOfqueries; i++)
            {
                var func = Console.ReadLine()?.Split();
                var param = Array.ConvertAll(Console.ReadLine()?.Split() ?? Array.Empty<string>(), int.Parse);
                if (func?[0] == "SORT")
                {
                    if (func.Length == 1 || func?[1] == "ASCENDING")
                    {
                        Console.WriteLine(string.Join(" ",Queries.Sort(param)));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ",Queries.Sort(param, true)));
                    }
                }
                else if (func?[0] == "IS_SORTED")
                {
                    if (func.Length == 1 || func?[1] == "ASCENDING")
                    {
                        Console.WriteLine(Queries.Is_Sorted(param) ? "YES" : "NO");
                    }
                    else
                    {
                        Console.WriteLine(Queries.Is_Sorted(param, true) ? "YES" : "NO");
                    }
                }
                else if (func?[0] == "GET_MAX")
                {
                    Console.WriteLine(Queries.GetMax(param));
                }
                else if (func?[0] == "APPEND")
                {
                    Console.WriteLine(string.Join(" ", Queries.AppendSorted(param,int.Parse(func?[1]))));
                }
                else if(func?[0] == "GET_HISTOGRAM")
                {
                    Console.WriteLine(string.Join(" ", Queries.GetHistogram(param,int.Parse(func?[1]))));
                }
            }
        }
    }
}