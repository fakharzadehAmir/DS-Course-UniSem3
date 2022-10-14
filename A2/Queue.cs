using System;

namespace A2
{
    // public class Queue
    // {
    //     public void Enqueue(object newNum) => this._queue[this._rear++] = newNum;
    //     
    //     public object Dequeue()
    //     {
    //         var num = this._queue[this._front];
    //         this._queue[this._front] = null;
    //         this._front++;
    //         return num;
    //     }
    //
    //     public int Size() => this._rear - this._front;
    //
    //     public bool IsEmpty() => this._front == this._rear;
    //     
    //     private readonly object[] _queue = new object[10000];
    //
    //     private int _rear, _front;
    // }

    // internal static class Program
    // {
    //     private static void Main()
    //     {
    //         var q = new Queue();
    //         string line;
    //         while ((line = Console.ReadLine()) != null && line != "")
    //         {
    //             if (line.Contains("enqueue"))
    //                 q.Enqueue(int.Parse(line.Split()[1]));
    //             else
    //                 switch (line)
    //                 {
    //                     case "dequeue":
    //                         Console.WriteLine(q.Dequeue());
    //                         break;
    //                     case "size":
    //                         Console.WriteLine(q.Size());
    //                         break;
    //                     case "isEmpty":
    //                         Console.WriteLine(q.IsEmpty());
    //                         break;
    //                 }
    //
    //         }
    //     }
    // }
}