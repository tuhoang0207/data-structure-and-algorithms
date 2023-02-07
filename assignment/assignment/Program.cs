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

        private static void Quick_Sort(List<Phone> arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(List<Phone> arr, int left, int right)
        {
            int pivot = arr[left].phoneId;
            while (true)
            {

                while (arr[left].phoneId < pivot)
                {
                    left++;
                }

                while (arr[right].phoneId > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    Phone temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        //merge sort
        public static void merge(List<Phone> arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] left = new int[n1];
            int[] right = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
            {
                left[i] = arr[l + i].price;
            }
                
            for (j = 0; j < n2; ++j)
            {
               right[j] = arr[m + 1 + j].price;
            }
             

            i = 0;
            j = 0;


            int k = l;
            while (i < n1 && j < n2)
            {
                if (left[i] <= right[j])
                {
                    arr[k].price = left[i];
                    i++;
                }
                else
                {
                    arr[k].price = right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k].price = left[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k].price = right[j];
                j++;
                k++;
            }
        }

     
        public static void sort(List<Phone> arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                int m = l + (r - l) / 2;

                // Sort first and
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
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
                        int arrLength1 = list.Count;
                        switch(optionReport)
                        {
                            case 1:
                                
                                Quick_Sort(list,0,arrLength1 - 1);

                                foreach (Phone item in list)
                                {
                                    Console.Write(" phone id " + item.phoneId);
                                    Console.Write(" phone number " + item.phoneNumber);
                                    Console.Write(" phone price  " + item.price);
                                    Console.Write("                               \n");
                                }
                                break;
                            case 2:
                                sort(list,0,arrLength1 - 1);
                                foreach (Phone item in list)
                                {
                                    Console.Write(" phone id " + item.phoneId);
                                    Console.Write(" phone number " + item.phoneNumber);
                                    Console.Write(" phone price  " + item.price);
                                    Console.Write("                               \n");
                                }
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
