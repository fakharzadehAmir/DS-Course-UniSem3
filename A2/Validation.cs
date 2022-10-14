// using System;
//
// namespace A2
// {
//     public class Stack
//     {
//         private void Push(char newChar) => _stack[_index++] = newChar;
//
//         private object Pop()
//         {
//             var num = _stack[_index - 1];
//             _stack[--_index] = '\0';
//             return num;
//         }
//         private bool IsEmpty() => _index == 0;
//         public bool CheckStack(string validation)
//         {
//             foreach (var v in validation)
//             {
//                 if (v == '{' || v == '[' || v == '(')
//                     Push(v);
//                 
//                 else if (v == '}' || v == ']' || v == ')')
//                 {
//                     if (IsEmpty() ||
//                         v != ')' && _stack[_index - 1] == '(' ||
//                         v != ']' && _stack[_index - 1] == '[' ||
//                         v != '}' && _stack[_index - 1] == '{' )
//                         return false;
//                     else
//                         this.Pop();
//                 }
//             }
//             return IsEmpty();
//         }
//
//         private int _index;
//         private readonly char[] _stack = new char[1000];
//     }
//     internal static class Program
//     {
//         private static void Main()
//         {
//             var s = new Stack();
//             Console.WriteLine(s.CheckStack(Console.ReadLine()) ? 1 : 0);
//         }
//     }
// }