﻿using System.Collections.Generic;

namespace SmartCargo
{
    static class Program
    {
        public static void Main()
        {
            var cargoInfo = Entering.CargoInfo();
            var unsortedСargos = SplitByParams(cargoInfo);
            var sortParam = Entering.ParamForSort();
            var sortingOrder = Entering.SortOrder();

            switch (sortParam)
            {
                case "NAME":
                    SortHelper.Word(unsortedСargos, 0, sortingOrder);
                    break;
                case "WEIGHT":
                    SortHelper.Weight(unsortedСargos, 1, sortingOrder);
                    break;
                case "DATE_BEGIN":
                    SortHelper.Word(unsortedСargos, 2, sortingOrder);
                    break;
                case "DATE_END":
                    SortHelper.Word(unsortedСargos, 3, sortingOrder);
                    break;
                case "IMPORTANCE_LEVEL":
                    SortHelper.Level(unsortedСargos, 4, sortingOrder);
                    break;
            }
        }

        private static string[][] SplitByParams(List<string> cargoInfo)
        {
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

            return unsortedСargos;
        }
    }
}



