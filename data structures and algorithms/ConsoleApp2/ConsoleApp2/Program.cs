// C# program to insert element in binary tree
using System;
using System.Collections.Generic;



class GFG
{
    class Student
    {
        int rollnumber;
        string studentname;
        string phonenumber;


        /* A binary tree node has key, pointer to
        left child and a pointer to right child */
        public class Node
        {
            public Student key;
            public Node left, right;

            // constructor
            public Node(Student key)
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
        static void insert(Node temp, Student key)
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

        static void insert(Student key)
        {
            root = insertRec(root, key);
        }

        static Node insertRec(Node root, Student key)
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
            if (key.rollnumber < root.key.rollnumber)
                root.left = insertRec(root.left, key);
            else if (key.rollnumber > root.key.rollnumber)
                root.right = insertRec(root.right, key);

            /* return the root */
            return root;
        }

        //processing
        public static object BinarySearchDisplay(int[] arr, int key)
        {
            int minNum = 0;
            int maxNum = arr.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == arr[mid])
                {
                    return ++mid;
                }
                else if (key < arr[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return "None";
        }

        static void treeins(List<Student> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Student s1 = new Student();
                s1.rollnumber = arr[i].rollnumber;
                insert(s1);
            }

        }

        static bool ifNodeExists(Node node, Student key)
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
            Student s1 = new Student();
            s1.rollnumber = 1;
            s1.studentname = "Tú";
            s1.phonenumber = "111";
            root = new Node(s1);
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
            List<Student> arr = new List<Student>();
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

                

                switch (option)
                {
                    case 1:
                        Student key = new Student();
                        Console.Write("enter new student ");
                        key.rollnumber = Convert.ToInt32(Console.ReadLine());
                        key.studentname = Console.ReadLine();
                        key.phonenumber = Console.ReadLine();
                        arr.Add(key);
                        insert(root, key);

                        foreach(Student s in arr)
                        {
                            Console.WriteLine("đang trong for");
                            Console.WriteLine(s.rollnumber);
                            Console.WriteLine(s.phonenumber);
                            Console.WriteLine(s.studentname);
                        }
                        break;
                    case 2:
                        Console.Write("enter value you want to find ");
                        //key = Convert.ToInt32(Console.ReadLine());
                        //if (ifNodeExists(root, key))
                        //{
                        //    Console.WriteLine("YES");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("NO");
                        //}
                        break;
                    case 3:

                        //treeins(arr);
                        inorder(root);
                        break;
                    case 4:
                        foreach (Student s in arr)
                        {
                            Console.WriteLine("đang trong for");
                            Console.WriteLine(s.rollnumber);
                            Console.WriteLine(s.phonenumber);
                            Console.WriteLine(s.studentname);
                        }
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;
                }
            } while (option != null);


        }
    }
}

