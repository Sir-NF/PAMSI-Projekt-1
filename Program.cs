using System;
using System.Diagnostics;

namespace Sortowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();

            while(true)
            {
                int sortWay;
                watch.Reset();
                Console.WriteLine("\n Wybierz opcje");
                Console.WriteLine("1: Testy efektywności ");
                Console.WriteLine("2: Testy efektywności - sortowanie procenta tablicy ");
                Console.WriteLine("3: Testy efektywności - sortowanie odwrotne ");
                int w = int.Parse(Console.ReadLine());
                watch.Start();
                switch(w)
                {                    
                    case 1: 
                        Console.WriteLine("Algorytm sortowania: ");
                        Console.WriteLine("1: QuickSort ");
                        Console.WriteLine("2: ShellSort ");
                        Console.WriteLine("3: HeapSort ");
                        sortWay = int.Parse(Console.ReadLine());
                        EfficiencyTests.RunEfficiencyTest(sortWay);
                        break;
                    case 2:
                        Console.WriteLine("Jaki procent z tablicy ma być na starcie posortowany (procent pisz z kropką) ? ");
                        double percent = double.Parse(Console.ReadLine());
                        Console.WriteLine("Algorytm sortowania: ");
                        Console.WriteLine("1: QuickSort ");
                        Console.WriteLine("2: ShellSort ");
                        Console.WriteLine("3: HeapSort ");
                        sortWay = int.Parse(Console.ReadLine());
                        int _percent = (int)(percent * 10);
                        EfficiencyTests.RunEfficiencyTest(_percent, sortWay);
                        break;
                    case 3:
                        Console.WriteLine("Algorytm sortowania: ");
                        Console.WriteLine("1: QuickSort ");
                        Console.WriteLine("2: ShellSort ");
                        Console.WriteLine("3: HeapSort ");
                        sortWay = int.Parse(Console.ReadLine());
                        EfficiencyTests.RunReversedSort(sortWay);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;                  
                }
                watch.Stop();
            }
        }
    }
}
