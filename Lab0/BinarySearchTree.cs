using System;

namespace Lab0
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {

        private BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
        }

        public bool IsEmpty => Root == null;

        public int Count { get; private set; }

        // TODO
        public int Height => HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Left == null && node.Right == null)
            {
                return 0;
            }

            int leftHeight = HeightRecursive(node.Left);
            int rightHeight = HeightRecursive(node.Right);

            return 1 + Math.Max(rightHeight, leftHeight);
        }

        // TODO
        public int? MinKey => MinKeyRecursive(Root);

        private int? MinKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node.Key;
            }
            else
            {
                return MinKeyRecursive(node.Left);
            }

        }

        // TODO
        public int? MaxKey => MaxKeyRecursive(Root);

        private int? MaxKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null)
            {
                return node.Key;
            }
            else
            {
                return MaxKeyRecursive(node.Left);
            }

        }

        // TODO
        public Tuple<int, T> Min => MinRecursive(Root);

        private Tuple<int, T> MinRecursive(BinarySearchTreeNode<T> node)
        {
            {
                if (node.Left == null)
                {
                    Tuple<int, T> minNode = new Tuple<int, T>(node.Key, node.Value);
                    return minNode;
                }
                else
                {
                    return MinRecursive(node.Left);
                }

            }

        }

        // TODO
        public Tuple<int, T> Max => MaxRecursive(Root);

        private Tuple<int, T> MaxRecursive(BinarySearchTreeNode<T> node)
        {
            {
                if (node.Left == null)
                {
                    Tuple<int, T> minNode = new Tuple<int, T>(node.Key, node.Value);
                    return minNode;
                }
                else
                {
                    return MaxRecursive(node.Right);
                }

            }

        }

        // TODO
        public double MedianKey
        {
            get
            {
                if (InOrderKeys.Count % 2 != 0)
                {
                    return InOrderKeys[InOrderKeys.Count / 2];
                }
                else
                {
                    return (InOrderKeys[InOrderKeys.Count / 2] + InOrderKeys[InOrderKeys.Count / 2 - 1]) / 2.0;
                }
            }

        }

        public BinarySearchTreeNode<T> GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Key == key)
            {
                return node;
            }
            else if (key < node.Key)
            {
                return GetNodeRecursive(node.Left, key);
            }
            else
            {
                return GetNodeRecursive(node.Right, key);
            }
        }


        // TODO
        public void Add(int key, T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(key, value);
                Count++;
            }
            else
            {
                AddRecursive(key, value, Root);
            }
        }
        // TODO
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> parent)
        {
            // duplicate found
            // do not add to BST
            if (key == parent.Key)
            {
                return;
            }

            if (key < parent.Key)
            {
                if (parent.Left == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value); 
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Count++;

                }
                else
                {
                    AddRecursive(key, value, parent.Left);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Count++;
                }
                else
                {
                    AddRecursive(key, value, parent.Right);
                }
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        public bool Contains(int key)
        {
            if (GetNode(key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // TODO
        // to the right, then as far left as possible
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            if (node.Right != null)
            {
                return MinNode(node.Right);
            }

            var parent = node.Parent;
            while (parent != null && node == parent.Right)
            {
                node = parent;
                parent = parent.Parent;
            }
            return parent;
        }

        // TODO
        // to the left, then as far right as possible
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            if (node.Left != null)
            {
                return MaxNode(node.Left);
            }

            var parent = node.Parent;
            while (parent != null && node == parent.Left)
            {
                node = parent;
                parent = parent.Parent;
            }
            return parent;
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            var nodes = new List<BinarySearchTreeNode<T>>();
            if (min < 0)
            {
                return nodes;
            }
            else
            {
                for (int i = min; i <= max; i++)
                {
                    nodes.Add(GetNode(i));
                }
                return nodes;
            }
        }

        public void Remove(int key)
        {

            var node = GetNode(key);
            var parent = node.Parent;

            if (node == null)
            {
                return;
            }

            Count--;

            // 1) Leaf node
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    node.Parent = null;
                }
                else
                {
                    parent.Right = null;
                    node.Parent = null;
                }
                return;
            }

            // 2) parent with one child
            if (node.Left == null && node.Right != null)
            {
                // only has a right child
                var child = node.Right;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;
                    node.Parent = null;
                    node.Right = null;
                }
                else
                {
                    parent.Right = child;
                    child.Parent = parent;
                    node.Parent = null;
                    node.Right = null;
                }
                return;
            }
            if (node.Left != null && node.Right == null)
            {
                // only has a left child
                var child = node.Left;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;
                    node.Parent = null;
                    node.Left = null;
                }
                else
                {
                    parent.Right = child;
                    child.Parent = parent;
                    node.Parent = null;
                    node.Left = null;
                }

                return;
            }

            // 3) parent with two children
            // Find the node to remove
            // determine it is a parent with 2 children
            // find the next node (successor)
            // swap key and data from successor to node
            // Remove the successor (leaf)
            if (node.Left != null && node.Right != null)
            {
                var sucessor = Next(node);
                node.Key = sucessor.Key;
                node.Value = sucessor.Value;
                Remove(sucessor.Key);
            }
        }

        // TODO
        public T Search(int key)
        {
            if (Contains(key))
            {
                return GetNode(key).Value;
            }
            else
            {
                return default(T);
            }
        }

        // TODO
        public void Update(int key, T value)
        {
            var node = GetNode(key);
            node.Value = value;
        }


        // TODO
        public List<int> InOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                InOrderKeysRecursive(Root, keys);

                return keys;

            }
        }

        private void InOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // left
            // root
            // right

            if (node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);

        }

        // TODO
        public List<int> PreOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PreOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void PreOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }

            keys.Add(node.Key);
            PreOrderKeysRecursive(node.Left, keys);
            PreOrderKeysRecursive(node.Right, keys);
        }

        // TODO
        public List<int> PostOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PostOrderKeysRecursive(Root, keys);
                return keys;
            }
        }

        private void PostOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }

            PostOrderKeysRecursive(node.Left, keys);
            PostOrderKeysRecursive(node.Right, keys);
            keys.Add(node.Key);

        }

        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            return MinNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MinNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return MinNodeRecursive(node.Left);
        }

        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            return MaxNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MaxNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }
            return MaxNodeRecursive(node.Right);
        }
    }
}

