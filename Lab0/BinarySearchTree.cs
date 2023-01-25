using System;
using System.Xml.Linq;

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
        public int Height => throw new NotImplementedException();

        // TODO
        public int MinKey => throw new NotImplementedException();

        // TODO
        public int MaxKey => throw new NotImplementedException();

        // TODO
        public Tuple<int, T> Min => throw new NotImplementedException();

        // TODO
        public Tuple<int, T> Max => throw new NotImplementedException();

        // TODO
        public double MedianKey => throw new NotImplementedException();


        public BinarySearchTreeNode<T> GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T> GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            return null;
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
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> node)
        {
            if (key < node.Key)
            {
                if (node.Left == null)
                {
                    node.Left = new BinarySearchTreeNode<T>(key, value);
                    Count++;
                }
                else
                {
                    AddRecursive(key, value, node.Left);
                }               
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinarySearchTreeNode<T> (key, value);
                    Count++;
                }
                else
                {
                    AddRecursive(key, value, node.Right);
                }
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        // TODO
        public bool Contains(int key)
        {
            throw new NotImplementedException();
        }

        // TODO
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        // TODO
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            throw new NotImplementedException();
        }

        // TODO
        public T Search(int key)
        {
            return SearchRecursive(Root, key);
        }

        private T SearchRecursive(BinarySearchTreeNode<T>node , int key)
        {
            if (node != null)
            {
                if (key == node.Key)
                {
                    return node.Value;
                }
                else if (key < node.Key)
                {
                    return SearchRecursive(node.Left, key);
                }
                else if (key > node.Key)
                {
                    return SearchRecursive(node.Right, key);
                }
            }
            return default(T);
        }

        // TODO
        public void Update(int key, T value)
        {
            throw new NotImplementedException();
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
            
        }
    }
}

