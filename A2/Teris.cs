using System;

namespace A2
{
    public class Stack
    {
        public void Push(string newStr) => this._stack[this._index++] = newStr;
        public string Pop()
        {
            var num = this._stack[this._index - 1];
            this._stack[--this._index] = null;
            return num;
        }
        public object Peek() => this._stack[this._index - 1];
        public int Size() => this._index;
        public bool IsEmpty() => this._index == 0;
    
        private int _index;
        private readonly string[] _stack = new string[16000];
    }

public class Teris
    {
        public void ReduceString(string text, string[] examples)
        {
            for (var i = text.Length - 1; i > -1; i--)
            {
                if(_stack.Size() == 0) 
                    _stack.Push(text[i].ToString()); 
                else if (Array.Exists(examples, s => s == text[i].ToString() + _stack.Peek()))
                    _stack.Pop();
                else
                    _stack.Push(text[i].ToString());
            }

            while (!_stack.IsEmpty())
                Console.Write(_stack.Pop());
            


        }

        private readonly Stack _stack = new Stack();

    }
    internal static class Program
    {
        private static void Main()
        {
            var examples = new[] {"as", "to", "by", "vs", "cd", "js", "py", "cs", "cp", "md"};
            var t = new Teris();
            t.ReduceString(Console.ReadLine(), examples);
        }
    }
}