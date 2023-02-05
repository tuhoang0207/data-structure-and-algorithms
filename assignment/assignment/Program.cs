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
                Console.Write("\n price " + tnode.data.price + " \n");
                tnode = tnode.next;
                count++;
            }

      
        }
        // Driver code

        static int binarySearch(List<Phone> arr, int low, int high, int value)
        {
            if (high >= low)
            {
                //find the middle of array
                int mid = low + (high - low) / 2;

                // If the element is present at the 
                // middle itself 
                if (arr[mid].phoneId == value)
                {
                    return mid;
                }
                    

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (arr[mid].phoneId > value)
                {
                    return binarySearch(arr, low, mid - 1, value);
                }

                // Else the element can only be present 
                // in right subarray 
                return binarySearch(arr, mid + 1, high, value);
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }

        public static void updatePhone()
        {
            Console.WriteLine("enter phone id you want to update ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach(Phone p in list)
            {
                if(p.phoneId == id)
                {
                    Console.WriteLine("enter new phone number ");
                    p.phoneNumber = Console.ReadLine();

                    Console.WriteLine("enter new phone number price");
                    p.price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("update successfully");
                }
            }
        }


        public static void deletePhone() {
            Console.WriteLine("enter phone id you want to delete ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Phone p in list)
            {
                if(list.Count == 0)
                {
                    Console.WriteLine("dont have any element in list");
                    return;
                }
                if (p.phoneId == id)
                {
                    list.Remove(p);
                    Console.WriteLine("update successfully");
                }
            }
        }
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

        public static List<Phone> SortArray(List<Phone> array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i].phoneId < pivot.phoneId)
                {
                    i++;
                }

                while (array[j].phoneId > pivot.phoneId)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i].phoneId;
                    array[i].phoneId = array[j].phoneId;
                    array[j].phoneId = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
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
                        int arrLength = list.Count;
                        Console.Write("enter phone id you want to find ");
                        int value = Convert.ToInt32(Console.ReadLine());

                        int result = binarySearch(list, 0, arrLength-1,value);

                        if (result == -1)
                        {
                            Console.WriteLine("Element not present");
                        }
                        else
                        {
                            Console.WriteLine("Element found at index " + result);
                        }
                        break;
                    case 3:
                        updatePhone();
                        printList();
                        break;
                    case 4:
                        deletePhone();
                        printList();
                        break;
                    case 5:
                        reportMenu();
                        
                        int optionReport;
                        Console.WriteLine("enter your option ");
                        optionReport = Convert.ToInt32(Console.ReadLine());
                        
                        switch(optionReport)
                        {
                            case 1:
                                int arrLength1 = list.Count;
                                SortArray(list,0,arrLength1 - 1);
                                break;
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
