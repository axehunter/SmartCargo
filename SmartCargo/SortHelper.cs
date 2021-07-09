using System;

namespace SmartCargo
{
    public static class SortHelper
    {
        public static void Level(string[][] unsortedСargos, int numberParametr, string sortingOrder)
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
                            MovingCargo(unsortedСargos, j);
                    }

            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] != "Низкий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] == "Низкий")
                            MovingCargo(unsortedСargos, j);
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
                            MovingCargo(unsortedСargos, j);
                    }

            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (unsortedСargos[j][numberParametr] != "Высокий")
                    {
                        if (unsortedСargos[j + 1][numberParametr] == "Высокий")
                            MovingCargo(unsortedСargos, j);
                    }

            OutputSortedResult(unsortedСargos);
        }
        public static void Word(string[][] unsortedСargos, int numberParametr, string sortingOrder)
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
                        MovingCargo(unsortedСargos, j);

            OutputSortedResult(unsortedСargos);
        }
        private static void WordSortDesc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (String.CompareOrdinal(unsortedСargos[j][numberParametr], unsortedСargos[j + 1][numberParametr]) < 0)
                        MovingCargo(unsortedСargos, j);

            OutputSortedResult(unsortedСargos);
        }
        public static void Weight(string[][] unsortedСargos, int numberParametr, string sortingOrder)
        {
            switch (sortingOrder)
            {
                case "ASC":
                    WeightSortAsc(unsortedСargos, numberParametr);
                    break;
                case "DESC":
                    WeightSortDesc(unsortedСargos, numberParametr);
                    break;
            }
        }
        private static void WeightSortAsc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (Convert.ToDouble(unsortedСargos[j][numberParametr]) > Convert.ToDouble(unsortedСargos[j + 1][numberParametr]))
                        MovingCargo(unsortedСargos, j);

            OutputSortedResult(unsortedСargos);
        }
        private static void WeightSortDesc(string[][] unsortedСargos, int numberParametr)
        {
            for (int i = 0; i < unsortedСargos.Length; i++)
                for (int j = 0; j < unsortedСargos.Length - 1; j++)
                    if (Convert.ToDouble(unsortedСargos[j][numberParametr]) < Convert.ToDouble(unsortedСargos[j + 1][numberParametr]))
                        MovingCargo(unsortedСargos, j);

            OutputSortedResult(unsortedСargos);
        }
        private static void MovingCargo(string[][] unsortedСargos, int j)
        {
            string[] t = unsortedСargos[j + 1];
            unsortedСargos[j + 1] = unsortedСargos[j];
            unsortedСargos[j] = t;
        }
        private static void OutputSortedResult(string[][] cargos)
        {
            Console.WriteLine("Результат обработки информации:");
            Console.WriteLine("Название   Вес   Дата отправки   Дата доставки   Уровень важности   Признак архивности");

            foreach (var cargo in cargos)
            {
                foreach (var param in cargo)
                {
                    Console.Write(param + "   ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}

