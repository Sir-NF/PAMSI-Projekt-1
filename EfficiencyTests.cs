using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class EfficiencyTests 
{
        private static int[] GenerateTab(int length)
        {
            Random random = new Random(); //Tworzę obiekt klasy Random, obiekt ten będzie generował losowe liczby
            
            int[] tabToReturn = new int[length];
            for(int i = 0; i < tabToReturn.Length; i++)
            {
                tabToReturn[i] = random.Next(1, tabToReturn.Length); //Generuje losową liczbę przy użyciu obiektu random, w argumentach przekazuję zakres liczb z jakiego random ma losować
            }

            return tabToReturn; 
        }

        private static int[] GenerateReversedTab(int length)
        {
            int[] tabToReturn = new int[length];
            
            for(int i = length - 1; i >= 0; i--)
            {
                tabToReturn[i] = i;
            }

            return tabToReturn;
        }

        private static void SortAllTabsFromList(List<int[]> list, int mode)
        {
            Time[] timeArray = new Time[list.Count]; //Tworzenie tablicy obiektów Time (Każdy pojedynczy obiekt klasy Time przechowuje informacje która tablica była sortowana i w jakim czasie)
           
            Console.WriteLine($"Sorting list of tabs with length {list[0].Length}");
           
            Stopwatch watch = new Stopwatch(); //Tworzenie obiektu klasy Stopwatch która będzie liczyć czas sortowania
           
            //kazda tablica z listy jest sortowana 
            for(int i = 0; i < list.Count; i++)
            {
                watch.Start(); //Rozpoczęcie odliczania czasu pojedynczego sortowania
                switch(mode)
                {
                    case 1:
                        QuickSort.Sort(list[i], 0, list[i].Length - 1);
                        break;
                    case 2:
                        ShellSort.Sort(list[i], list[i].Length);
                        break;
                    case 3:
                        HeapSort.Sort(list[i], list[i].Length);
                        break;
                }
                watch.Stop(); //Koniec odliczania czasu pojedynczego sortowania
               
                Console.WriteLine($"Tab nr {i} sort time {watch.ElapsedMilliseconds}");
                Time time = new Time(){tabNumber = i, time = watch.ElapsedMilliseconds}; //Tworzę nowy obiekt klasy Time, zapisuje w nim informację o tym która tablica była sortowana oraz czas sortowania 
                timeArray[i] = time; //Dodaje ten obiekt Time do tablicy Time'ów która na końcu będzie zapisana do pliku XML
                watch.Reset(); //Po każdej iteracji resetuje czas odliczania
            }

            XmlSerializer serializer = new XmlSerializer(typeof(TimeToSave)); /*Tworzę nowy obiekt klasy XmlSerializer 
            która posłuży do zapisania danych o czasie sortowań do pliku XML (w argumencie przekazuje typ obiektu jaki będzie zapisany do pliku XML)
            czyli TimeToSave, w nim przechowam tablicę Time'ów którą stworzyłem na samym początku tej metody ("Time[] timeArray = new Time[list.Count]")
             */

            TimeToSave timeArrayToSave = new TimeToSave() {time = timeArray}; //Tworzę obiekt TimeToSave i zapisuje w nim tablicę Time'ów

            //Zapisuje czasy sortowań do pliku XML, blok using sprawi że po zapisie, strumienie zostaną zamknięte dzięki czemu nie będzie problemów później z korzystaniem z pliku XML
            using (TextWriter writer = new StreamWriter($"TabsSortTimeLength{list[0].Length}.xml"))
            {
                serializer.Serialize(writer, timeArrayToSave);
            }

            Console.WriteLine($"List is sorted");
        }

        //Metoda sortująca określony procent początkowych elementów tablicy 
        private static void SortAllTabsFromList(List<int[]> list, float percent)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Array.Sort(list[i], 0, (int)(list[i].Length * percent / 1000));
            }
        }

        private static List<List<int[]>> CreateLists()
        {
            //Tworze 5 list, kazda bedzie zawierać po 100 tablic
            List<int[]> first = new List<int[]>();
            List<int[]> second = new List<int[]>();
            List<int[]> third = new List<int[]>();
            List<int[]> fourth = new List<int[]>();
            List<int[]> fifth = new List<int[]>();

            //Dodanie tych 5 list do jednej listy 
            List<List<int[]>> listOfLists = new List<List<int[]>>()
            {
                first, second, third, fourth, fifth
            };

            return listOfLists;
        }

        
        //Metoda wypełniająca listę tablicami 
        private static void FillLists(List<List<int[]>> listOfLists)
        {
            //Ta pętla wypełnia listy tablicami 
            int tabLength = 1000000;
            for(int i = 4; i >= 0; i--)
            {
                for(int j = 0; j < 100; j++)
                {
                    listOfLists[i].Add(GenerateTab(tabLength)); //Dla każdej iteracji wygenerowanie losowo tablicy
                }
                if(i % 2 == 0) //Warunek sprawdzający czy tabLength ma być podzielony przez 2 czy też 5
                {
                    tabLength /= 2;
                } else 
                {
                    tabLength /= 5;
                }
            }
        }

        public static void RunEfficiencyTest(int SortWay)
        {
            List<List<int[]>> listOfLists = CreateLists();

            FillLists(listOfLists);

            foreach (List<int[]> list in listOfLists)
            {
                SortAllTabsFromList(list, SortWay);
            }
        }

        public static void RunReversedSort(int SortWay)
        {
            List<List<int[]>> listOfLists = CreateLists();

            FillLists(listOfLists);

            foreach (List<int[]> list in listOfLists)
            {
                SortAllTabsFromList(list, SortWay);
            }
        }

        public static void RunEfficiencyTest(float percent, int SortWay)
        {
            List<List<int[]>> listOfLists = CreateLists();

            FillLists(listOfLists);

            foreach (List<int[]> list in listOfLists)
            {
                SortAllTabsFromList(list, percent); //Posortowanie procenta elementów tablicy
            }

            foreach (List<int[]> list in listOfLists)
            {
                SortAllTabsFromList(list, SortWay); //Posortowanie całej tablicy
            }
        }
}