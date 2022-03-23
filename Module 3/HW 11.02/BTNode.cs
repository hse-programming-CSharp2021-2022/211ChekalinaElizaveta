using System;
using System.Collections.Generic;
using System.Text;

namespace HW_11._02
{
    public class BTNode<T> where T : IComparable, IEquatable<T>
    {
        private int count;
        public BTNode<T> Left { get; private set; }
        public BTNode<T> Right { get; private set; }
        private T value;

        public BTNode(T value)
        {
            this.count = 1;
            this.value = value;
            this.Left = null;
            this.Right = null;
        }

        public void Preorder()
        {
            if (this.Left is not null)
            {
                
                this.Left.Preorder();
            }

            Console.WriteLine(this);
            if (this.Right is not null)
            {
                this.Right.Preorder();
            }
        }
        
        public void InOrder()
        {
            if (this.Right is not null)
            {
                this.Right.Preorder();
            }

            Console.WriteLine(this);
            if (this.Left is not null)
            {
                this.Left.Preorder();
            }
        }

        public BTNode<T> Find(T other)
        {

            BTNode<T> res = null;
            if (this.value.Equals(other))
            {
                return this;
            }
            if (this.Left is not null)
            {
                res = this.Left.Find(other);
                if (res is not null)
                {
                    return res;
                }
            }
            if (this.Right is not null)
            {
                res = this.Right.Find(other);
                if (res is not null)
                {
                    return res;
                }
            }

            return null;
        }


        public bool DeleteChild(BTNode<T> child)
        {
            if (this.Left is not null && this.Left.value.Equals(child.value))
            {
                this.Left = null;
                return true;
            }
            if (this.Right is not null && this.Right.value.Equals(child.value))
            {
                this.Right = null;
                return true;
            }

            bool res = false;
            if (this.Left is not null)
            {
                res = res | this.Left.DeleteChild(child);
            }

            if (res)
                return true;
            if (this.Right is not null)
            {
                res = res | this.Right.DeleteChild(child);
            }

            return res;

        }

        public bool HasChild(BTNode<T> other)
        {
            bool res = this.value.Equals(other.value);
            if (res)
                return true;
            if (this.Left is not null)
            {
                res |= this.Left.value.Equals(other.value);
            }
            if (res)
                return true;
            if (this.Right is not null) {
                res |= this.Right.value.Equals(other.value);
                
            }

            return res;
        }
        public void InsertValue(T value)
        {
            int comp = value.CompareTo(this.value);
            if (comp == 0)
            {
                this.count += 1;
            }

            if (comp < 0)
            {
                if (this.Right != null)
                {
                    this.Right.InsertValue(value);
                    return;
                }

                this.Right = new BTNode<T>(value);
            }

            if (this.Left != null)
            {
                this.Left.InsertValue(value);
                return;
            }
            this.Left = new BTNode<T>(value);
        }


        public override string ToString()
        {
            return $"Node: {value.ToString()}";
        }
    }
}