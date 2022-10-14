// using System;
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
//         public void Swap(params int[] idx)
//         {
//             if(idx[0] == idx[1]) return;
//             var current = _head;
//             Node prev = null, next = null, start = null, end = null;
//             for (var i = 0;
//                 i < idx[1] + 1 && current != null;
//                 i++, current = current.Next)
//             {
//                 if (i < idx[0])
//                     prev = current;
//                 else if (i == idx[0])
//                     start = current;
//                 else if (i == idx[1])
//                 {
//                     next = current.Next;
//                     end = current;
//                 }
//             }
//             if (end != null) end.Next = null;
//             end = this.Reverse(start);
//             if (prev != null)
//                 prev.Next = end;
//             else
//                 this._head = end;
//             if (start != null) start.Next = next;
//         }
//
//         private Node Reverse(Node head)
//         {
//             Node pNode = null, nNode = null;
//             var current = head;
//             while (current != null) {
//                 nNode = current.Next;
//                 current.Next = pNode;
//                 pNode = current;
//                 current = nNode;
//             }
//             return pNode;
//         }
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
//              return final;
//         }
//         private Node _head;
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var l = new LinkedList(Array.ConvertAll(Console.ReadLine()?.Split(),int.Parse));
//             l.Swap(Array.ConvertAll(Console.ReadLine()?.Split(), int.Parse));
//             Console.WriteLine(l.Print());
//         }
//     }
// }