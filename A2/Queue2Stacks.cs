// using System;
//
// namespace A2
// {
//     public class Stack
//     {
//         public void Push(object newNum) => this._stack[this.Index++] = newNum;
//         public object Pop()
//         {
//             var num = this._stack[this.Index - 1];
//             this._stack[--this.Index] = null;
//             return num;
//         }
//         public int Index;
//         private readonly object[] _stack = new object[10000];
//     
//     }
//     public class Queue2Stacks
//     {
//         public void Enqueue(object newNum) => _stack1.Push(newNum);
//         
//         public object Dequeue()
//         {
//             while (_stack1.Index > 1)
//                 _stack2.Push(_stack1.Pop());
//             var num = _stack1.Pop();
//             while (_stack2.Index > 0)
//                 _stack1.Push(_stack2.Pop());
//             return num;
//         }
//         public int Size() => _stack1.Index;
//         public bool IsEmpty() => _stack1.Index == 0;
//         private readonly Stack _stack1 = new Stack();
//         private readonly Stack _stack2 = new Stack();
//         
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var q = new Queue2Stacks();
//             string line;
//             while ((line = Console.ReadLine()) != null && line != "")
//             {
//                 if (line.Contains("enqueue"))
//                     q.Enqueue(int.Parse(line.Split()[1]));
//                 else
//                     switch (line)
//                     {
//                         case "dequeue":
//                             Console.WriteLine(q.Dequeue());
//                             break;
//                         case "size":
//                             Console.WriteLine(q.Size());
//                             break;
//                         case "isEmpty":
//                             Console.WriteLine(q.IsEmpty());
//                             break;
//                     }
//     
//             }
//         }
//     }
// }