using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort2
{
    class Program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; // number of comparasion
        private int mov_count = 0; // number of data movements

        // Nummber of elements in array
        private int n;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements");
            }
            Console.WriteLine("\n==========================");
            Console.WriteLine("Enter array elements");
            Console.WriteLine("\n==========================");

            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        //Swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp; 

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;  
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //Partition the list into two parts:
            // one containing elements less that or equal to pivot
            // outher containning elements greather than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //Search for an element greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //Search for an element lens than or equal to pivot
                while((arr[j] > pivot) && (i >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                //Search forn an element less than or equal to pivot
                if (i < j) // if the greater element is on the left of the element
                {
                    //Swap the element at index i with the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            if (low < j)
            {
                swap(low, j);
                mov_count++;
            }
            // sort the list on the left of the pivot using quick sort
            q_sort(low, j - 1);

            //Sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n----------------------");
            Console.WriteLine(" Sort array elements");
            Console.WriteLine("------------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparisons: " + cmp_count);
            Console.WriteLine("\nNumber of data movements : " + mov_count);
        }
        int getSize()
        {
            return n;
        }
        static void Main(string[] args)
        {
            //Declaring the object of the class
            Program myList = new Program();
            //Accept array elements
            myList.input();
            //Calling the sorting function
            //frist call to quick sort Algorithm
            myList.q_sort(0, myList.getSize()-1);
            //Display sorted array 
            myList.display();
            //to exit from the console
            Console.WriteLine("\n\nPress Enter to exit.");
            Console.Read();
        }
    }   
}















