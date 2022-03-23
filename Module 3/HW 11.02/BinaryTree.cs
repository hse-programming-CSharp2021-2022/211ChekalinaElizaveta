using System;

namespace HW_11._02
{
    public class BinaryTree<ElemType> where ElemType : IComparable, IEquatable<ElemType>
    {
        private BTNode<ElemType> root;

        public BinaryTree()
        {
        }

        public BinaryTree(BTNode<ElemType> root)
        {
            this.root = root;
        }

        public void Insert(ElemType val)
        {
            if ( this.root is null)
            {
                this.root = new BTNode<ElemType>(val);
            }
            else
            {
                root?.InsertValue(val);
            }
        }

        public BTNode<ElemType> Find(ElemType nodeValue)
        {
            return this.root.Find(nodeValue);
        }

        public bool Delete(BTNode<ElemType> node)
        {
            if (!this.Contains(node))
            {
                return false;
            }

            this.root.DeleteChild(node);
            return true;
        }

        public bool Contains(BTNode<ElemType> node)
        {
            return root.HasChild(node);
        }

        public void Preorder(BTNode<ElemType> node)
        {
            if (this.Contains(node))
            {
                node.Preorder();
            }
        }

        public void Print()
        {
            if (this.root != null)
            {
                this.root.Preorder();
                
            }
            else
            {
                throw new InvalidOperationException("Treee is empty.");
            }
        }

        public void InOrder()
        {
            if (root is not null)
            {
                this.root.InOrder();
            }
            else
            {

                throw new InvalidOperationException("Treee is empty.");
            }
        }

        public bool IsEmpty => this.root is null;

        public void Clear() => root = null;
    }
}