// C# program to insert element in binary tree
using System;
using System.Collections.Generic;

class GFG
{
    struct Student
    {
        int rollnumber;
        string studentname;
        string phonenumber;
    }

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

    static void insert(int key)
    {
        root = insertRec(root, key);
    }

    static Node insertRec(Node root, int key)
    {

        /* If the tree is empty,
            return a new node */
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        /* Otherwise, recur
            down the tree */
        if (key < root.key)
            root.left = insertRec(root.left, key);
        else if (key > root.key)
            root.right = insertRec(root.right, key);

        /* return the root */
        return root;
    }

    static void treeins(List<int> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            insert(arr[i]);
        }

    }

    static bool ifNodeExists(Node node, int key)
    {
        if (node == null)
            return false;

        if (node.key == key)
            return true;

        // then recur on left subtree /
        bool res1 = ifNodeExists(node.left, key);

        // node found, no need to look further
        if (res1) return true;

        // node is not found in left,
        // so recur on right subtree /
        bool res2 = ifNodeExists(node.right, key);

        return res2;
    }
    // Driver code
    public static void Main(String[] args)
    {
        root = new Node(10);
        //root.left = new Node(11);
        //root.left.left = new Node(7);
        //root.right = new Node(9);
        //root.right.left = new Node(15);
        //root.right.right = new Node(8);

        //Console.Write(
        //    "Inorder traversal before insertion:");
        //inorder(root);


        //int option = Convert.ToInt32(Console.ReadLine());
        //int key;
        int option;
      
        do
        {
            Console.WriteLine("=============================\n");
            Console.WriteLine("Student Management System\n");
            Console.WriteLine("=============================\n");
            Console.WriteLine("1. Add student\n");
            Console.WriteLine("2. Search by student name\n");
            Console.WriteLine("3. Sort by roll number\n");
            Console.WriteLine("4. Display all students\n");

            Console.WriteLine("enter your option ");
            option = Convert.ToInt32(Console.ReadLine());
            int key;
            List<int> arr = new List<int>();
            switch (option)
            {
                case 1:
                    Console.Write("enter new node ");
                    key = Convert.ToInt32(Console.ReadLine());
                    arr.Add(key);
                    insert(root, key);
                    break;
                case 2:
                    Console.Write("enter value you want to find ");
                    key = Convert.ToInt32(Console.ReadLine());
                    if (ifNodeExists(root, key))
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                    break;
                case 3:
                
                    treeins(arr);
                    inorder(root);
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        } while (option != null);


    }
}

// This code is contributed by Rajput-Ji
