using System;
using System.Collections.Generic;

namespace SmartCargo
{
    public static class Entering
    {
        public static string SortOrder()
        {
            Console.WriteLine("Введите порядок сортировки: ASC, DESC");
            var sortingOrder = Console.ReadLine()?.ToUpper();
            return sortingOrder;
        }

        public static string ParamForSort()
        {
            Console.WriteLine("Введите параметр, по которому необходимо отсортировать:");
            string[] cargoParams = { "NAME", "WEIGHT", "DATE_BEGIN", "DATE_END", "IMPORTANCE_LEVEL" };
            for (int i = 0; i < cargoParams.Length; i++)
                Console.WriteLine(cargoParams[i] + " ");
            var sortParam = Console.ReadLine()?.ToUpper();
            return sortParam;
        }

        public static List<string> CargoInfo()
        {
            Console.WriteLine(
                "Введите необходимую информацию о грузах — через ; без пробелов. Если вы закончили, введите слово END.");

            List<string> cargoInfo = new List<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END") break;
                cargoInfo.Add(line);
            }

            return cargoInfo;
        }
    }
}
