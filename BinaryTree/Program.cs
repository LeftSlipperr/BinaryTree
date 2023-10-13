using System;
using BinaryTree;

class Program
{
    static void Main(string[] args)
    {
        var tree = new Tree<int>();
        tree.Add(10);
        tree.Add(5);
        tree.Add(15);
        tree.Add(11);
        tree.Add(18);
        tree.Add(20);

        PrintTree(tree.Root, "", true);
        Console.WriteLine("Enter a number to search: ");
        int searchValue = Convert.ToInt32(Console.ReadLine());
        bool isFound = tree.Contains(searchValue);
        Console.WriteLine($"Search for {searchValue}: {isFound}");
    }

    static void PrintTree(Node<int> node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                indent += "│   ";
            }
            Console.WriteLine(node.Data);
            PrintTree(node.Right, indent, false); // Правое поддерево первым
            PrintTree(node.Left, indent, true);    // Затем левое поддерево
        }
    }
}
