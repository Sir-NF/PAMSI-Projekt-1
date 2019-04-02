using System; 
using System.Diagnostics;

public static class QuickSort 
{
            // szybkie sortowanie
        public static void Sort(int[] tab, int left, int right)
        {
            var i = left;   
            var j = right; 
            var pivot = tab[(left + right) / 2]; // punkt osiowy

            while(i<j)
            {
                while(tab[i] < pivot) i++;
                while(tab[j] > pivot) j--;
                if (i<=j)
                { 
                    var tmp = tab[i];
                    tab[i++] = tab[j];
                    tab[j--]= tmp;
                }
            }
            if (left < j) Sort(tab, left, j);
            if (i < right) Sort(tab, i, right);
        }
}