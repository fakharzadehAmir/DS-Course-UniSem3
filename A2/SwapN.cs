// using System;
//
// namespace A2
// {
//     public class Node
//     {
//         public int Data;
//         public Node Next;
//     }
//     public class LinkedList
//     {
//         public LinkedList(params int[] numbers)
//         {
//             foreach (var i in numbers)
//                 this.Add(i);
//         }
//         private void Add(int newNum)
//         {
//             if (_head != null)
//             {
//                 var current = _head;
//                 while (current.Next != null)
//                     current = current.Next;
//                 current.Next = new Node() {Data = newNum};
//             }
//             else
//                 _head = new Node() {Data = newNum};
//         }
//         public int Size()
//         {
//             var i = 0;
//             var current = _head;
//             while (current != null)
//             {
//                 i++;
//                 current = current.Next;
//             }
//             return i;
//         }
//
//         public void Swap(int idx)
//         {
//             if (idx == 0 || idx == Size()) return;
//             else
//             {
//                 var current = _head;
//                 for (var i = 0; i < idx - 1; i++)
//                     current = current.Next;
//                 var head = current.Next;
//                 current.Next = null;
//                 var newHead = head;
//                 while (newHead.Next != null)
//                     newHead = newHead.Next;
//                 newHead.Next = _head;
//                 _head = head;
//             }
//         }
//
//
//         public string Print()
//         {
//             var final = "";
//              var current = _head;
//              while (current != null)
//              {
//                  if (current.Next != null)
//                      final += $"{current.Data} ";
//                  else
//                      final += $"{current.Data}";
//                  current = current.Next;
//              }
//
//              return final;
//         }
//         
//         private Node _head;
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var l = new LinkedList(Array.ConvertAll(Console.ReadLine()?.Split(),int.Parse));
//             l.Swap(int.Parse(Console.ReadLine()));
//             Console.WriteLine(l.Print());
//
//         }
//     }
// }