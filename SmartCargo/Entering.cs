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
            while (true)
            {
                Console.WriteLine("Введите порядок сортировки: ASC, DESC");
                var sortingOrder = Console.ReadLine()?.ToUpper();
                string[] sortParams = {"ASC", "DESC"};
                if (!sortParams.Contains(sortingOrder))
                {
                    Console.WriteLine("Порядок сортировки введен не верно.");
                    continue;
                }
                return sortingOrder;
            }
        }

        public static string ParamForSort()
        {
            while (true)
            {
                Console.WriteLine("Введите название параметра, по которому необходимо отсортировать. Возможные значения:");
                string[] cargoParams = { "NAME", "WEIGHT", "DATE_BEGIN", "DATE_END", "IMPORTANCE_LEVEL" };
                for (int i = 0; i < cargoParams.Length; i++)
                    Console.Write(cargoParams[i] + "   ");
                Console.WriteLine("");
                var sortParam = Console.ReadLine()?.ToUpper();

                if (!cargoParams.Contains(sortParam))
                {
                    Console.WriteLine("Название параметра введено не верно.");
                    continue;
                }
                return sortParam;
            }
        }

        public static List<string> CargoInfo()
        {
            Console.BufferWidth = 250;
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
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                DateTime.ParseExact(param[2], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
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
