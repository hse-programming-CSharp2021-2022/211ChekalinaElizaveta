using System;
using System.Collections.Generic;
namespace Task01
{
    class Stack<T>
    {
        private List<T> list = new();
        public void Push(T item)
        {
            list.Add(item);
        }
        public T Top()
        {
            if (list.Count > 0)
            {
                return list[list.Count-1];
            }
            throw new InvalidOperationException("No values in stack.");
            
        }
        
        public T Pop()
        {
            if (list.Count > 0)
            {
                T item = list[list.Count - 1];
                list.RemoveAt(list.Count-1);
                return item;
            }
            throw new InvalidOperationException("No values in stack.");
        }

        public int Size()
        {
            return this.list.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(4);
            stack.Push(5);
            stack.Push(1);
            Console.WriteLine(stack.Top());
            stack.Push(8);
            stack.Pop();
            Console.WriteLine(stack.Top());
        }
    }
}