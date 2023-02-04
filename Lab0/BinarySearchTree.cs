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
        public int Height =>  IsEmpty ? 0 : HeightRecursive(Root);

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
        public int? MinKey => MinNode(Root).Key;

        // TODO
        public int? MaxKey => MaxNode(Root).Key;

        // TODO
        public Tuple<int, T> Min
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }
                var minNode = MinNode(Root);
                return Tuple.Create(minNode.Key, minNode.Value);
            }
        }

        // TODO
        public Tuple<int, T> Max
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }
                var maxNode = MaxNode(Root);
                return Tuple.Create(maxNode.Key, maxNode.Value);

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
            //Method 1 = use Next()
            /* var nodes = new List<BinarySearchTreeNode<T>>();
            BinarySearchTreeNode<T> startingNode;*/

            // Method 2 = use InOrderKeys
            var nodes = new List<BinarySearchTreeNode<T>>();
            if (min > max)
            {
                return nodes;
            }
            var orderedKeys = InOrderKeys;
            foreach(int key in orderedKeys)
            {
                if (key >= min && key <= max)
                {
                    nodes.Add(GetNode(key));
                }
            }
            return nodes;

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
                
                // if the node is root
                if (node.Parent == null)
                {
                    Root = child;
                    return;
                }

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

                // if the node is root
                if (node.Parent == null)
                {
                    Root = child;
                    return;
                }

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
                var sucessorKey = sucessor.Key;
                var sucessorValue = sucessor.Value;
                Remove(sucessor.Key);
                node.Key = sucessorKey;
                node.Value = sucessorValue;
                return;

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

