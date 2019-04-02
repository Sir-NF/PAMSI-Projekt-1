using System;

public static class HeapSort 
{
// Sortowanie przez kopcowanie
        public static void Sort(int[] tab, int n)
        {
            for(int i = n / 2 - 1; i>=0; i--)
                heapify(tab, n, i);
            for(int i = n-1; i>=0; i--)
            {
                int temp = tab[0];
                tab[0] = tab[i];
                tab[i] = temp;
                heapify(tab, i, 0);
            }
        }

        static void heapify(int[] tab, int n, int i)  
        {
            int largest = i; 
            int left = 2*i + 1;
            int right = 2*i + 2;

            if(left < n && tab[left] > tab[largest])
                largest = left;
            if(right < n && tab[right] > tab[largest])
                largest = right;
            if(largest != i)
            {
                int swap = tab[i];
                tab[i] = tab[largest];
                tab[largest] = swap;
                heapify(tab, n, largest);
            }
        }
}