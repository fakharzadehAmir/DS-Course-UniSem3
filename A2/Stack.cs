using System;

namespace A2
{
    // public class Stack
    // {
    //     public void Push(object newNum) => this._stack[this._index++] = newNum;
    //     public object Pop()
    //     {
    //         var num = this._stack[this._index - 1];
    //         this._stack[--this._index] = null;
    //         return num;
    //     }
    //     public object Peek() => this._stack[this._index - 1];
    //     public int Size() => this._index;
    //     public bool IsEmpty() => this._index == 0;
    //
    //     private int _index;
    //     private readonly object[] _stack = new object[16000];
    //
    // }

    // internal static class Program
    // {
    //     private static void Main()
    //     {
    //         var s = new Stack();
    //         string line;
    //         while ((line = Console.ReadLine()) != null && line != "")
    //         {
    //             if (line.Contains("push"))
    //                 s.Push(int.Parse(line.Split()[1]));
    //             else
    //                 switch (line)
    //                 {
    //                     case "pop":
    //                         Console.WriteLine(s.Pop());
    //                         break;
    //                     case "peek":
    //                         Console.WriteLine(s.Peek());
    //                         break;
    //                     case "size":
    //                         Console.WriteLine(s.Size());
    //                         break;
    //                     case "isEmpty":
    //                         Console.WriteLine(s.IsEmpty());
    //                         break;
    //                 }
    //      
    //         }
    //     }
    // }
}