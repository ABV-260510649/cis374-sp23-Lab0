namespace Lab0;
class Program
{
    static void Main(string[] args)
    {
        /*BinarySearchTree<int> tree = new BinarySearchTree<int>();
        int index = 0;
        for (int i = 0; i < 50; i++)
        {
            index = (i + 13) % 50;
            tree.Add(index, index);
        }

        BinarySearchTreeNode<int> current = new BinarySearchTreeNode<int>(1, 1);
        for (int i = 0; i < 49; i++)
        {
            current = tree.GetNode(i);
            Console.WriteLine( (tree.Search(i + 1), tree.Next(current).Value));
        }*/

        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Add(5, 7);
        tree.Add(4, 5);
        Console.WriteLine( (tree.Search(5), tree.Next(tree.GetNode(4)).Value));
    }

}


