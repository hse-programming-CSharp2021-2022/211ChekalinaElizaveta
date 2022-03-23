using System;

namespace HW_11._02
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            for (var i = 0; i < 5; i++)
            {
                tree.Insert(i);
            }
            tree.Print();
        }
    }
}