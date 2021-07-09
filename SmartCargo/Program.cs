using System;
using System.Collections.Generic;

namespace SmartCargo
{
    class Program
    {
        public static void Main()
        {

            Console.WriteLine("Введите необходимую информацию о грузах — через ; без пробелов. Если вы закончили, введите слово END.");

            string[] cargoParams = new string[] { "NAME", "WEIGHT", "DATE_BEGIN", "DATE_END", "IMPORTANCE_LEVEL" };

            List<string> cargoInfo = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END") break;
                cargoInfo.Add(line);
            }

            foreach (var item in cargoInfo)
                Console.WriteLine(item);

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



        }
    }
}



