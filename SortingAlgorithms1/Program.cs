using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements to sort: ");
            int n = int.Parse(Console.ReadLine());

            // Generate random numbers
            int[] numbers = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                numbers[i] = random.Next(1, n); // Random numbers between 1 and 99
            }

            Console.WriteLine("\nOriginal Array:");
            PrintArray(numbers);

            // Display sorting options
            Console.WriteLine("\nChoose a sorting algorithm:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Cocktail Shaker Sort");
            Console.WriteLine("3. Comb Sort");
            Console.WriteLine("4. Counting Sort");
            Console.WriteLine("5. Gnome Sort");
            Console.WriteLine("6. Heap Sort");
            Console.WriteLine("7. Insertion Sort");
            Console.WriteLine("8. Pancake Sort");
            Console.WriteLine("9. Merge Sort");
            Console.WriteLine("10. Quick Sort");
            Console.WriteLine("11. Radix Sort");
            Console.WriteLine("12. Selection Sort");
            Console.WriteLine("13. Shell Sort");
            Console.WriteLine("14. Stupid Sort");
            Console.WriteLine("15. Tim Sort");



            Console.Write("Enter choice (1-15): ");
            int choice = int.Parse(Console.ReadLine());

            int[] numbersToSort = (int[])numbers.Clone(); // Clone original array for sorting

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nRunning Bubble Sort...");
                    BubbleSortWithSteps(numbersToSort);
                    break;
                case 2:
                    Console.WriteLine("\nRunning Cocktail Shaker Sort...");
                    CocktailShakerSortWithSteps(numbersToSort);
                    break;
                case 3:
                    Console.WriteLine("\nRunning Comb Sort...");
                    CombSortWithSteps(numbersToSort);
                    break;
                case 4:
                    Console.WriteLine("\nRunning Counting Sort...");
                    CountingSortWithSteps(numbersToSort);
                    break;
                case 5:
                    Console.WriteLine("\nRunning Gnome Sort...");
                    GnomeSortWithSteps(numbersToSort);
                    break;
                case 6:
                    Console.WriteLine("\nRunning Heap Sort...");
                    HeapSortWithSteps(numbersToSort);
                    break;
                case 7:
                    Console.WriteLine("\nRunning Insertion Sort...");
                    InsertionSortWithSteps(numbersToSort);
                    break;
                case 8:
                    Console.WriteLine("\nRunning Merge Sort...");
                    MergeSortWithSteps(numbersToSort, 0, numbersToSort.Length - 1);
                    break;
                case 9:
                    Console.WriteLine("\nRunning Pancake Sort...");
                    PancakeSortWithSteps(numbersToSort);
                    break;
                case 10:
                    Console.WriteLine("\nRunning Quick Sort...");
                    QuickSortWithSteps(numbersToSort, 0, numbersToSort.Length - 1);
                    break;
                case 11:
                    Console.WriteLine("\nRunning Radix Sort...");
                    RadixSortWithSteps(numbersToSort);
                    break;
                case 12:
                    Console.WriteLine("\nRunning Selection Sort...");
                    SelectionSortWithSteps(numbersToSort);
                    break;
                case 13:
                    Console.WriteLine("\nRunning Shell Sort...");
                    ShellSortWithSteps(numbersToSort);
                    break;
                case 14:
                    Console.WriteLine("\nRunning Stupid Sort...");
                    StupidSortWithSteps(numbersToSort);
                    break;
                case 15:
                    Console.WriteLine("\nRunning Tim Sort...");
                    TimSortWithSteps(numbersToSort);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting program.");
                    return;
            }

            Console.WriteLine("\nSorted Array:");
            PrintArray(numbersToSort);
            Console.ReadLine();
        }

        static void BubbleSortWithSteps(int[] array)
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap the elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        // Display array after each swap
                        PrintArray(array);
                        Thread.Sleep(200); // 0.2-second pause for visualization

                        swapped = true;
                    }
                }

                // If no swaps occurred in this pass, array is sorted
                if (!swapped)
                    break;
            }
        }

        static void CocktailShakerSortWithSteps(int[] array)
        {
            {
                bool swapped = true;
                int start = 0;
                int end = array.Length - 1;

                while (swapped)
                {
                    swapped = false;

                    // Forward pass: move larger elements to the end
                    for (int i = start; i < end; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            Swap(array, i, i + 1);

                            // Display array after each swap
                            PrintArray(array);
                            Thread.Sleep(200); // 0.2-second pause for visualization

                            swapped = true;
                        }
                    }

                    // If no elements were swapped, the array is sorted
                    if (!swapped)
                        break;

                    // Move the endpoint back by one since the end element is sorted
                    end--;

                    // Backward pass: move smaller elements to the beginning
                    swapped = false;
                    for (int i = end - 1; i >= start; i--)
                    {
                        if (array[i] > array[i + 1])
                        {
                            Swap(array, i, i + 1);

                            // Display array after each swap
                            PrintArray(array);
                            Thread.Sleep(200); // 0.2-second pause for visualization

                            swapped = true;
                        }
                    }

                    // Move the start point forward since the start element is sorted
                    start++;
                }
            }
        }

        static void CombSortWithSteps(int[] array)
        {
            int n = array.Length;
            int gap = n;
            bool swapped = true;

            while (gap != 1 || swapped)
            {
                // Update the gap for the next comb
                gap = GetNextGap(gap);
                swapped = false;

                // Perform a "comb" through the array with the current gap
                for (int i = 0; i < n - gap; i++)
                {
                    if (array[i] > array[i + gap])
                    {
                        Swap(array, i, i + gap);
                        PrintArray(array); Thread.Sleep(200);
                        swapped = true;
                    }
                }
            }
        }

        static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            return (gap < 1) ? 1 : gap;
        }

        static void CountingSortWithSteps(int[] array)
        {
            int max = array[0];
            foreach (int num in array) if (num > max) max = num;

            int[] count = new int[max + 1];
            foreach (int num in array) count[num]++;

            int index = 0;
            for (int i = 0; i <= max; i++)
            {
                while (count[i]-- > 0)
                {
                    array[index++] = i;
                    PrintArray(array);
                    Thread.Sleep(200);
                }
            }
        }

        static void GnomeSortWithSteps(int[] array)
        {
            int index = 0;
            while (index < array.Length)
            {
                if (index == 0 || array[index] >= array[index - 1])
                    index++;
                else
                {
                    Swap(array, index, index - 1);
                    PrintArray(array); Thread.Sleep(200);
                    index--;
                }
            }
        }

        static void HeapSortWithSteps(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap(array, 0, i);
                PrintArray(array);
                Thread.Sleep(200);
                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                Swap(array, i, largest);
                Heapify(array, n, largest);
            }
        }

        static void InsertionSortWithSteps(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    PrintArray(array);
                    Thread.Sleep(200);
                }
                array[j + 1] = key;
                PrintArray(array);
            }
        }

        static void MergeSortWithSteps(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSortWithSteps(array, left, mid);
                MergeSortWithSteps(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    array[k++] = L[i++];
                }
                else
                {
                    array[k++] = R[j++];
                }
                PrintArray(array);
                Thread.Sleep(200);
            }

            while (i < n1)
            {
                array[k++] = L[i++];
                PrintArray(array);
                Thread.Sleep(200);
            }

            while (j < n2)
            {
                array[k++] = R[j++];
                PrintArray(array);
                Thread.Sleep(200);
            }
        }

        static void PancakeSortWithSteps(int[] array)
        {
            for (int currentSize = array.Length; currentSize > 1; currentSize--)
            {
                // Find the index of the maximum element in the unsorted section
                int maxIndex = FindMaxIndex(array, currentSize);

                // Bring the max element to the front if it's not already
                if (maxIndex != currentSize - 1)
                {
                    Flip(array, maxIndex);
                    PrintArray(array); Thread.Sleep(200);

                    // Move the max element to its correct position
                    Flip(array, currentSize - 1);
                    PrintArray(array); Thread.Sleep(200);
                }
            }
        }

        static int FindMaxIndex(int[] array, int n)
        {
            int maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > array[maxIndex])
                    maxIndex = i;
            }
            return maxIndex;
        }

        static void Flip(int[] array, int i)
        {
            int start = 0;
            while (start < i)
            {
                Swap(array, start, i);
                start++;
                i--;
            }
        }

        static void QuickSortWithSteps(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Partition the array and get the pivot index
                int pivotIndex = Partition(array, low, high);

                // Recursively sort elements before and after the partition
                QuickSortWithSteps(array, low, pivotIndex - 1);
                QuickSortWithSteps(array, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];  // Choose the rightmost element as the pivot
            int i = low - 1;           // Pointer for the greater element

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);

                    // Display array after each swap
                    PrintArray(array);
                    Thread.Sleep(200); // 0.2-second pause for visualization
                }
            }

            // Swap the pivot element to its correct position
            Swap(array, i + 1, high);
            PrintArray(array);  // Print array after final swap with pivot
            Thread.Sleep(200);  // 0.2-second pause for visualization

            return i + 1; // Return the index of the pivot
        }

        static void RadixSortWithSteps(int[] array)
        {
            int max = array[0];
            foreach (int num in array) if (num > max) max = num;

            for (int exp = 1; max / exp > 0; exp *= 10)
                CountingSortForRadix(array, exp);
        }

        static void CountingSortForRadix(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(array[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
                PrintArray(array);
                Thread.Sleep(200);
            }
        }

        static void SelectionSortWithSteps(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIdx])
                    {
                        minIdx = j;
                    }
                }

                if (minIdx != i)
                {
                    Swap(array, i, minIdx);
                    PrintArray(array);
                    Thread.Sleep(200);
                }
            }
        }

        static void ShellSortWithSteps(int[] array)
        {
            int n = array.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                        PrintArray(array);
                        Thread.Sleep(200);
                    }
                    array[j] = temp;
                }
            }
        }

        static void StupidSortWithSteps(int[] array)
        {
            Random random = new Random();
            while (!IsSorted(array))
            {
                // Randomly shuffle the array
                for (int i = 0; i < array.Length; i++)
                {
                    int randomIndex = random.Next(array.Length);
                    Swap(array, i, randomIndex);

                    // Display array after each swap
                    PrintArray(array);
                    Thread.Sleep(200); // 0.2-second pause for visualization
                }
            }
        }

        static void TimSortWithSteps(int[] array)
        {
            int n = array.Length;
            const int RUN = 32;

            // Sort individual subarrays of size RUN using Insertion Sort
            for (int i = 0; i < n; i += RUN)
                InsertionSortForTimSort(array, i, Math.Min((i + RUN - 1), (n - 1)));

            // Merge subarrays in a bottom-up manner
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));
                    if (mid < right)
                        Merge(array, left, mid, right);
                }
            }
        }

        static void InsertionSortForTimSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= left && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
                PrintArray(array); Thread.Sleep(200);
            }
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }
            return true;
        }

        static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
