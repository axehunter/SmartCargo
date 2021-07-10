using System.Collections.Generic;

namespace SmartCargo
{
    static class Program
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
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
            foreach (var line in cargoInfo)
            {
                if (line == "")
                    continue;
                string[] param = line.Split(new[] { ';' });
                unsortedСargos[index] = param;
                index++;
            }
            return unsortedСargos;
        }
    }
}



