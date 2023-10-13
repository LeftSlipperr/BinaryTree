using System;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class Node<T> where T : IComparable<T>
    {
        public T Data { get; private set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int Height { get; set; }

        public Node(T data)
        {
            Data = data;
            Height = 1;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left), GetHeight(Right)) + 1;
        }

        private int GetHeight(Node<T> node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        public int GetBalanceFactor()
        {
            return GetHeight(Left) - GetHeight(Right);
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public void Add(T data)
        {
            if (data.CompareTo(Data) < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);
                }
                else
                {
                    Right.Add(data);
                }
            }

            UpdateHeight();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
