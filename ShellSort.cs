using System;

public static class ShellSort 
{
        public static void Sort(int[] tab, int n)
        {
            int i, j, pos, temp; 
            pos = 5; 
           
            while (pos > 0)
            {
                for(i=0; i < n; i++)
                {
                    j=i;
                    temp = tab[i];

                    while((j >= pos) && (tab[j - pos] > temp))
                    {
                        tab[j] = tab[j - pos];
                        j = j - pos;
                    }
                    tab[j] = temp;
                }
                if(pos / 2 != 0)
                    pos = pos / 2;

                else if(pos == 1)
                    pos = 0;

                else
                    pos = 1;
            }
        }   
}