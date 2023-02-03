// C# program to insert element in binary tree
using System;
using System.Collections.Generic;

class GFG
{

    /* A binary tree node has key, pointer to
	left child and a pointer to right child */
    public class Node
    {
        public int key;
        public Node left, right;

        // constructor
        public Node(int key)
        {
            this.key = key;
            left = null;
            right = null;
        }
    }
    static Node root;

    /* Inorder traversal of a binary tree*/
    static void inorder(Node temp)
    {
        if (temp == null)
            return;

        inorder(temp.left);
        Console.Write(temp.key + " ");
        inorder(temp.right);
    }

    /*function to insert element in binary tree */
    static void insert(Node temp, int key)
    {
        if (temp == null)
        {
            root = new Node(key);
            return;
        }
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(temp);

        // Do level order traversal until we find
        // an empty place.
        while (q.Count != 0)
        {
            temp = q.Peek();
            q.Dequeue();

            if (temp.left == null)
            {
                temp.left = new Node(key);
                break;
            }
            else
                q.Enqueue(temp.left);

            if (temp.right == null)
            {
                temp.right = new Node(key);
                break;
            }
            else
                q.Enqueue(temp.right);
        }
    }

    static void deleteDeepest(Node root, Node delNode)
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        Node temp = null;

        // Do level order traversal until last node
        while (q.Count != 0)
        {
            temp = q.Peek();
            q.Dequeue();

            if (temp == delNode)
            {
                temp = null;
                return;
            }
            if (temp.right != null)
            {
                if (temp.right == delNode)
                {
                    temp.right = null;
                    return;
                }

                else
                    q.Enqueue(temp.right);
            }

            if (temp.left != null)
            {
                if (temp.left == delNode)
                {
                    temp.left = null;
                    return;
                }
                else
                    q.Enqueue(temp.left);
            }
        }
    }

    // Function to delete given element
    // in binary tree
    static void delete(Node root, int key)
    {
        if (root == null)
            return;

        if (root.left == null && root.right == null)
        {
            if (root.key == key)
            {
                root = null;
                return;
            }
            else
                return;
        }

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        Node temp = null, keyNode = null;

        // Do level order traversal until
        // we find key and last node.
        while (q.Count != 0)
        {
            temp = q.Peek();
            q.Dequeue();

            if (temp.key == key)
                keyNode = temp;

            if (temp.left != null)
                q.Enqueue(temp.left);

            if (temp.right != null)
                q.Enqueue(temp.right);
        }

        if (keyNode != null)
        {
            int x = temp.key;
            deleteDeepest(root, temp);
            keyNode.key = x;
        }
    }


    static void findFullNode(Node root)
    {
        if (root != null)
        {
            findFullNode(root.left);
            if (root.left != null && root.right != null)
                Console.Write(root.key + " ");
            findFullNode(root.right);
        }
    }
    // Driver code
    public static void Main(String[] args)
    {
        root = new Node(10);
        root.left = new Node(11);
        root.left.left = new Node(7);
        root.right = new Node(9);
        root.right.left = new Node(15);
        root.right.right = new Node(8);

        //Console.Write(
        //    "Inorder traversal before insertion:");
        //inorder(root);


        //int option = Convert.ToInt32(Console.ReadLine());
        //int key;
        int option;
        do
        {
            Console.WriteLine("enter your option ");
            option = Convert.ToInt32(Console.ReadLine());
            int key;
            switch (option)
            {
                case 1:
                    Console.Write("enter new node ");
                    key = Convert.ToInt32(Console.ReadLine());
                    insert(root, key);
                    break;
                case 2:
                    Console.Write("enter value you want delete ");
                    key = Convert.ToInt32(Console.ReadLine());
                    delete(root, key);
                    break;
                case 3:
                    inorder(root);
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        } while(option != null);
       
       
    }
}

// This code is contributed by Rajput-Ji
