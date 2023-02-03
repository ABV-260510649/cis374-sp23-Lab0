using System.Xml.Linq;

namespace Lab0;
class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Add(8, 9);
        tree.Add(10, 11);
        tree.Add(6, 7);
        tree.Add(5, 6);
        tree.Add(22, 23);
        tree.Add(26, 27);
        tree.Add(7, 8);
        tree.Add(23, 24);

        tree.Remove(8);
        tree.Remove(10);
        tree.Remove(6);
        tree.Remove(5);
        tree.Remove(23);
        tree.Remove(7);
        tree.Remove(22);
        Console.WriteLine( (0, tree.Height));
        Console.WriteLine( (tree.GetNode(8)));
        Console.WriteLine( (tree.GetNode(26)));
        tree.Remove(26);

    }

}


