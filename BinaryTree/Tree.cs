using System;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            Root = Insert(Root, data);
        }

        public bool Contains(T data)
        {
            return Search(Root, data);
        }

        public List<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Preorder(Root);
        }

        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);

                list.AddRange(Preorder(node.Left));
                list.AddRange(Preorder(node.Right));
            }
            return list;
        }

        private bool Search(Node<T> node, T data)
        {
            if (node == null)
            {
                return false;
            }

            int comparison = data.CompareTo(node.Data);
            if (comparison == 0)
            {
                return true;
            }
            else if (comparison < 0)
            {
                return Search(node.Left, data);
            }
            else
            {
                return Search(node.Right, data);
            }
        }

        private Node<T> Insert(Node<T> node, T data)
        {
            if (node == null)
            {
                Count++;
                return new Node<T>(data);
            }

            if (data.CompareTo(node.Data) > 0)
            {
                node.Right = Insert(node.Right, data);
            }
            else if (data.CompareTo(node.Data) < 0)
            {
                node.Left = Insert(node.Left, data);
            }
            else
            {
                return node; // Уже существует, не добавляем
            }

            // Обновление высоты
            node.UpdateHeight();

            // Балансировка
            int balance = node.GetBalanceFactor();

            // Левое поддерево наклонено влево
            if (balance > 1)
            {
                if (data.CompareTo(node.Left.Data) < 0)
                {
                    return RotateRight(node);
                }
                if (data.CompareTo(node.Left.Data) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }
            }

            // Правое поддерево наклонено вправо
            if (balance < -1)
            {
                if (data.CompareTo(node.Right.Data) > 0)
                {
                    return RotateLeft(node);
                }
                if (data.CompareTo(node.Right.Data) < 0)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }
            }

            return node;
        }


        private Node<T> RotateRight(Node<T> y)
        {
            Node<T> x = y.Left;
            Node<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.UpdateHeight();
            x.UpdateHeight();

            return x;
        }

        private Node<T> RotateLeft(Node<T> x)
        {
            Node<T> y = x.Right;
            Node<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.UpdateHeight();
            y.UpdateHeight();

            return y;
        }
    }
}
