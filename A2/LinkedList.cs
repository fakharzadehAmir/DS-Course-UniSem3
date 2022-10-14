// using System;
//
// namespace A2
// {
//     public class Node
//     {
//         public string Data;
//         public Node Next;
//     }
//
//     public class LinkedList
//     {
//         public void Add(string newStr) => _head = new Node() {Data = newStr, Next = _head};
//
//         public void Append(string newStr)
//         {
//             if (_head != null)
//             {
//                 var current = _head;
//                 while (current.Next != null)
//                     current = current.Next;
//                 current.Next = new Node() {Data = newStr};
//             }
//             else
//                 _head = new Node() {Data = newStr};
//
//         }
//
//         public void PrintSll()
//         {
//             var current = _head;
//             while (current != null)
//             {
//                 Console.Write(current.Next != null ? $"{current.Data} " : $"{current.Data}");
//                 current = current.Next;
//             }
//         }
//
//         public int IndexOf(string str)
//         {
//             var idx = 0;
//             var current = _head;
//             while (current.Data != str)
//             {
//                 idx++;
//                 current = current.Next;
//             }
//             return idx;
//         }
//
//         public void Insert(int idx, string newIData)
//         {
//             if (idx != 0)
//             {
//                 var current = _head;
//                 for (var i = 0; i < idx - 1; i++)
//                     current = current.Next;
//                 current.Next = new Node() {Data = newIData, Next = current.Next};
//             }
//             else
//                 _head = new Node() {Data = newIData, Next = _head};
//         }
//
//         public void Delete(int idx)
//         {
//             if (idx != 0)
//             {
//                 var current = _head;
//                 for (var i = 0; i < idx - 1; i++)
//                     current = current.Next;
//                 current.Next = current.Next.Next; 
//             }
//             else
//                 _head = _head.Next;
//         }
//         private Node _head;
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var l = new LinkedList();
//             string line;
//             while ((line = Console.ReadLine()) != null && line != "")
//             {
//                 switch (line.Split()[0])
//                 {
//                     case "add":
//                         l.Add(line.Split()[1]);
//                         break;
//                     case "append":
//                         l.Append(line.Split()[1]);
//                         break;
//                     case "insert":
//                         l.Insert(int.Parse(line.Split()[1]),line.Split()[2]);
//                         break;
//                     case "delete":
//                         l.Delete(int.Parse(line.Split()[1]));
//                         break;
//                     case "indexOf":
//                         Console.WriteLine(l.IndexOf(line.Split()[1]));
//                         break;
//                     case "printSLL":
//                         l.PrintSll();
//                         break;
//                 }
//             }
//         }
//     }
// }