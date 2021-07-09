using System;
using System.Collections.Generic;

namespace SmartCargo
{
    class Program
    {
        public static void Main()
        {

            Console.WriteLine("Введите необходимую информацию о грузах — через ; без пробелов. Если вы закончили, введите слово END.");

            string[] cargoParams = { "NAME", "WEIGHT", "DATE_BEGIN", "DATE_END", "IMPORTANCE_LEVEL" };

            List<string> cargoInfo = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END") break;
                cargoInfo.Add(line);
            }

            string[][] unsortedСargos = new string[cargoInfo.Count][];

            int index = 0;
            foreach (var item in cargoInfo)
            {
                if (item == "")
                    continue;
                string[] param = item.Split(new[] { ';' });
                unsortedСargos[index] = param;
                index++;
            }
            Console.WriteLine("Введите параметр, по которому необходимо отсортировать:");
            for (int i = 0; i < cargoParams.Length; i++)
                Console.WriteLine(cargoParams[i] + " ");
            var sortParam = Console.ReadLine();
            Console.WriteLine("Введите порядок сортировки: ASC, DESC");
            var sortingOrder = Console.ReadLine();
            switch (sortParam)
            {
                case "NAME":
                    WordSort(unsortedСargos, 0, sortingOrder);
                    break;
                case "WEIGHT":
                    BubbleSort(unsortedСargos, 1, sortingOrder);
                    break;
                case "DATE_BEGIN":
                    WordSort(unsortedСargos, 2, sortingOrder);
                    break;
                case "DATE_END":
                    WordSort(unsortedСargos, 3, sortingOrder);
                    break;
                case "IMPORTANCE_LEVEL":
                    LevelSort(unsortedСargos, 4, sortingOrder);
                    break;
            }
        }

        private static void LevelSort(string[][] unsortedСargos, int numberParametr, string sortingOrder)
        {
            switch (sortingOrder)
            {
                case "ASC":
                    LevelSortAsc(unsortedСargos, numberParametr);
                    break;
                case "DESC":
                    LevelSortDesc(unsortedСargos, numberParametr);
                    break;
            }
        }

        private static void LevelSortAsc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] == "Высокий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] != "Высокий")
                        {
                            string[] t = unsortedСargos[j + 1];
                            unsortedСargos[j + 1] = unsortedСargos[j];
                            unsortedСargos[j] = t;
                        }
                    }

            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] != "Низкий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] == "Низкий")
                        {
                            string[] t = unsortedСargos[j + 1];
                            unsortedСargos[j + 1] = unsortedСargos[j];
                            unsortedСargos[j] = t;
                        }
                    }

            OutputSortedResult(unsortedСargos);
        }

        private static void LevelSortDesc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] == "Низкий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] != "Низкий")
                        {
                            string[] t = unsortedСargos[j + 1];
                            unsortedСargos[j + 1] = unsortedСargos[j];
                            unsortedСargos[j] = t;
                        }
                    }

            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] != "Высокий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] == "Высокий")
                        {
                            string[] t = unsortedСargos[j + 1];
                            unsortedСargos[j + 1] = unsortedСargos[j];
                            unsortedСargos[j] = t;
                        }
                    }

            OutputSortedResult(unsortedСargos);
        }

        private static void WordSort(string[][] unsortedСargos, int numberParametr, string sortingOrder)
        {
            switch (sortingOrder)
            {
                case "ASC":
                    WordSortAsc(unsortedСargos, numberParametr);
                    break;
                case "DESC":
                    WordSortDesc(unsortedСargos, numberParametr);
                    break;
            }
        }

        private static void WordSortAsc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (string.CompareOrdinal(unsortedСargos[j][numberParametr], unsortedСargos[j + 1][numberParametr]) > 0)
                    {
                        string[] t = unsortedСargos[j + 1];
                        unsortedСargos[j + 1] = unsortedСargos[j];
                        unsortedСargos[j] = t;
                    }

            OutputSortedResult(unsortedСargos);
        }

        private static void WordSortDesc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (String.CompareOrdinal(unsortedСargos[j][numberParametr], unsortedСargos[j + 1][numberParametr]) < 0)
                    {
                        string[] t = unsortedСargos[j + 1];
                        unsortedСargos[j + 1] = unsortedСargos[j];
                        unsortedСargos[j] = t;
                    }

            OutputSortedResult(unsortedСargos);
        }

        private static void OutputSortedResult(string[][] unsortedСargos)
        {
            int index = 0;
            foreach (var item in unsortedСargos)
            {
                Console.WriteLine("ГРУЗ " + index);
                index++;
                foreach (var item2 in item)
                    Console.WriteLine(item2);
            }
        }

        private static void BubbleSort(string[][] unsortedСargos, int numberParametr, string sortingOrder)
        {
            switch (sortingOrder)
            {
                case "ASC":
                    BubbleSortAsc(unsortedСargos, numberParametr);
                    break;
                case "DESC":
                    BubbleSortDesc(unsortedСargos, numberParametr);
                    break;
            }
        }

        private static void BubbleSortAsc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (Convert.ToDouble(unsortedСargos[j][numberParametr]) > Convert.ToDouble(unsortedСargos[j + 1][numberParametr]))
                    {
                        string[] t = unsortedСargos[j + 1];
                        unsortedСargos[j + 1] = unsortedСargos[j];
                        unsortedСargos[j] = t;
                    }

            OutputSortedResult(unsortedСargos);
        }

        private static void BubbleSortDesc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (Convert.ToDouble(unsortedСargos[j][numberParametr]) < Convert.ToDouble(unsortedСargos[j + 1][numberParametr]))
                    {
                        string[] t = unsortedСargos[j + 1];
                        unsortedСargos[j + 1] = unsortedСargos[j];
                        unsortedСargos[j] = t;
                    }

            OutputSortedResult(unsortedСargos);
        }
    }
}



