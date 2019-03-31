using System;
using System.Collections.Generic;

namespace Interviews.DataStructures.SortingTests
{
    public class Sorting
    {
        public int[] numbers;

        public Sorting(int[] n)
        {
            this.numbers = n;
        }

        public void Print(int[] n)
        {
            Console.WriteLine($"Print array:");

            for (int i = 0; i < n.Length; i++)
            {
                Console.Write($"{n[i]}");
            }
            Console.WriteLine($"");
        }

        public void Swap(int[] arrayNumbers, int firstIndex, int secondIndex)
        {
            int temp = arrayNumbers[firstIndex];
            arrayNumbers[firstIndex] = arrayNumbers[secondIndex];
            arrayNumbers[secondIndex] = temp;
        }

        public static void Run()
        {
            Console.WriteLine("");
            Console.WriteLine(" *(*(*(*(*(*(*(*)()*)*)Sorting*(*(*(*(*)*)(*)(*()*)(*)(*)(*) ");
            int[] sample = new int[] { 6, 1, 7, 8, 9, 3, 5, 4, 2 };
            Sorting sortingProblems = new Sorting(sample);
            Console.WriteLine($"Unsorted array:");
            sortingProblems.Print(sortingProblems.numbers);
            Console.WriteLine($"Calling SelectionSort() on array:");
            sortingProblems.Print(sortingProblems.SelectionSort(sortingProblems.numbers));
            Console.WriteLine($"Unsorted array:");
            sortingProblems.Print(sortingProblems.numbers);
            Console.WriteLine($"Calling MergeSort() on array:");
            sortingProblems.Print(sortingProblems.MergeSort(sortingProblems.numbers));
            Console.WriteLine($"Unsorted array:");
            sortingProblems.Print(sortingProblems.numbers);
            Console.WriteLine($"Calling BubbleSort() on array:");
            sortingProblems.Print(sortingProblems.BubbleSort(sortingProblems.numbers));

        }


        public int[] SelectionSort(int[] unsorted)
        {
            int[] localNumbers = unsorted;
            for (int i = 0; i < localNumbers.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < localNumbers.Length; j++)
                {
                    if (localNumbers[j] < localNumbers[minIndex]) { minIndex = j; }
                }
                if (minIndex != i) { this.Swap(localNumbers, minIndex, i); }
            }
            return localNumbers;
        }

        public int[] MergeSort(int[] unsorted)
        {
            int[] localNumbers = unsorted;
            if (unsorted.Length <= 1) { return unsorted; }
            int mid = unsorted.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[(unsorted.Length % 2 == 0) ? mid : mid + 1];
            for (int i = 0; i < mid; i++) { left[i] = unsorted[i]; }
            for (int i = mid; i < unsorted.Length; i++) { right[i - mid] = unsorted[i]; }
            left = MergeSort(left);
            right = MergeSort(right);
            return MergeSort(left, right);
        }
        private int[] MergeSort(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            //int leftIndex = 0; int rightIndex = 0;
            int i = 0, j = 0;
            int index = 0;
            // List is not really used to return data. I think its left over from a previous implementation
            List<int> list = new List<int>();

            // Start from 0 and loop until either of the arrays run out numbers.
            for (; i < left.Length && j < right.Length;)
            {
                if (left[i] < right[j]) { list.Add(left[i]); result[index++] = left[i++]; }
                else if (left[i] > right[j]) { list.Add(right[j]); result[index++] = right[j++]; }
                else if (left[i] == right[j]) { list.Add(left[i]); list.Add(right[j]); result[index++] = left[i++]; result[index++] = right[j++]; }

            }
            // If the left arrray is longer than the right array and there are items left in the left array,
            // add them to the result.
            // And then vice versa.
            while (i < left.Length) { list.Add(left[i]); result[index++] = left[i++]; }
            while (j < right.Length) { list.Add(right[j]); result[index++] = right[j++]; }
            return result;
        }

        public int[] BubbleSort(int[] unsorted)
        {
            bool isArrayUnsorted = true;
            int[] localNumbers = unsorted;
            while (isArrayUnsorted)
            {
                isArrayUnsorted = false;
                for (int i = 0; i < localNumbers.Length - 1; i++)
                {
                    if (localNumbers[i] > localNumbers[i + 1]) { this.Swap(localNumbers, i, i + 1); isArrayUnsorted = true; }
                }
            }

            return localNumbers;
        }

        public int[] QuickSort(int[] unsorted, int low, int high)
        {
            int[] localNumbers = unsorted; int pi;
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is now
                   at right place */
                pi = partition(localNumbers, low, high);

                QuickSort(localNumbers, low, pi - 1);  // Before pi
                QuickSort(localNumbers, pi + 1, high); // After pi
            }


            return localNumbers;
        }

        private int partition(int[] localNumbers, int low, int high)
        {
            throw new NotImplementedException();
        }
    }
}
