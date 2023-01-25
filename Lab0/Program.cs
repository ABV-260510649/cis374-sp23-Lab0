namespace Lab0;
class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<char> tree = new BinarySearchTree<char>();
        char random = ' ';
        for (int i = 0; i < 50; i++)
        {
            random = (char)i;
            tree.Add(i, random);
            Console.WriteLine((random, tree.Search(i)));
        }
    }
}

