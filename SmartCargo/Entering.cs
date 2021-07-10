using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            Console.WriteLine("Введите название параметра, по которому необходимо отсортировать. Возможные значения:");
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
                if (CheckParams(line)) continue;

                cargoInfo.Add(line);
            }

            if (cargoInfo.Count == 0)
            {
                Console.WriteLine("Информация не введена. Работа программы завершена");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return cargoInfo;
        }

        private static bool CheckParams(string line)
        {
            string[] param = line.Split(new[] { ';' });
            if (param[0].Replace(" ", "") == "" || param[0].Length > 30)
            {
                Console.WriteLine(
                    "Название груза должно быть заполнено, но его длина не может превышать 30 символов, груз не принят для сортировки");
                return true;
            }

            if (Convert.ToDouble(param[1]) < 0 || Convert.ToDouble(param[1]) > 999999.999)
            {
                Console.WriteLine("Вес груза должен быть в диапазоне 0 и 999999.999, груз не принят для сортировки");
                return true;
            }

            if (string.CompareOrdinal(param[2], param[3]) > 0)
            {
                Console.WriteLine("Дата отправки не должна быть больше даты доставки, груз не принят для сортировки");
                return true;
            }

            try
            {
                DateTime.ParseExact(param[2], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime.ParseExact(param[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Не верный формат даты, груз не принят для сортировки");
                return true;
            }

            var cargoImportance = new String[] { "Низкий", "Средний", "Высокий" };
            if (!cargoImportance.Contains(param[4]))
            {
                Console.WriteLine("Уровень важности может принимать одно из следующих значений: Низкий, Средний, Высокий");
                return true;
            }
            var archiveLabel = new String[] { "Активный", "Архивный" };
            if (!archiveLabel.Contains(param[5]))
            {
                Console.WriteLine("Признак архивности может принимать одно из следующих значений: Активный, Архивный");
                return true;
            }

            return false;
        }
    }
}
