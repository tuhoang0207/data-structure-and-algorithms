// C# program to insert element in binary tree
using System;
using System.Collections.Generic;
class GFG
{
    class Phone
    {
        int phoneId;
        string phoneNumber;
        int price;
        

        /* A binary tree node has key, pointer to
        left child and a pointer to right child */
        /* Linked list Node*/
        
        public class Node
        {
            public Phone data;
            public Node next;
            public Node(Phone d) { data = d; next = null; }
        }

        static Node head = null;
        static List<Phone> list = new List<Phone>();

        /*function to insert element in binary tree */
        public static void insert(Phone new_data)
        {
            
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
            list.Add(new_data);
        }

        public static void printList()
        {
            Node tnode = head;
            int count = 0;
            while (tnode != null)
            {
                Console.Write((count+1) + ". phone id " + tnode.data.phoneId + " ");
                Console.Write("\n phone number " + tnode.data.phoneNumber + " ");
                Console.Write("\n price " + tnode.data.price + " ");
                tnode = tnode.next;
                count++;
            }

      
        }
        // Driver code

        public static void mainMenu()
        {
            Console.WriteLine("\n----------- Mobile Phone Shop ---------\n");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("1. Add mobile phone\n");
            Console.WriteLine("2. Search mobile phone\n");
            Console.WriteLine("3. Update mobile\n");
            Console.WriteLine("4. Delete mobile phone\n");
            Console.WriteLine("5. Shop reports\n");
            Console.WriteLine("0. Exit\n");
        }


        public static void reportMenu()
        {
            Console.WriteLine("\n----------- Mobile Phone Shop ---------\n");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("\tShop Reports\n");
            Console.WriteLine("1. Display all mobile phones\n");
            Console.WriteLine("2. Display top 5 highest price mobile phones\n");
            Console.WriteLine("0. Back to main menu\n");
        }
        public static void Main(String[] args)
        {
       
      
            int option;
            List<Phone> arr = new List<Phone>();
            do
            {
                mainMenu();

                Console.WriteLine("enter your option ");
                option = Convert.ToInt32(Console.ReadLine());



                switch (option)
                {
                    case 1:
                        Phone phone = new Phone();
                        Console.WriteLine("enter new phone id");
                        phone.phoneId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter new phone number");
                        phone.phoneNumber = Console.ReadLine();
                        Console.WriteLine("enter phone number price ");
                        phone.price = Convert.ToInt32(Console.ReadLine());

                        insert(phone);
                        printList();
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
                        //inorder(root);
                        break;
                    case 4:
                        //foreach (Phone s in arr)
                        //{
                        //    Console.WriteLine("đang trong for");
                        //    Console.WriteLine(s.rollnumber);
                        //    Console.WriteLine(s.phonenumber);
                        //    Console.WriteLine(s.studentname);
                        //}
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;
                }
            } while (option != null);


        }
    }
}
