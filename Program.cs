
//из бруска длиной L c ребрами a, b был выточен цилиндр длиной l имеющий радиус r.
// (r<=a/2, r<=b/2, l<= L).
//вычислить объем бруска и цилиндра, а также процент материала, ушедшего в отходы.



using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using System.Globalization;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Здравствуйте!! Давайте узнаем объем бруска и цилиндра, а также процент материала на отходы)");

            double a = 0.0, b = 0.0, L = 0.0, l = 0.0;
            bool[] isValid = { false, false, false, false, false };

            while (isValid[4] == false)
            {
                if (isValid[0] == false)
                {
                    Console.Write("Введите первое ребро бруска: \t");
                    if (!IsValidInput(out a))
                        continue;
                    isValid[0] = true;
                }
                if (isValid[1] == false)
                {
                    Console.Write("Введите второе ребро бруска: \t");
                    if (!IsValidInput(out b))
                        continue;
                    isValid[1] = true;
                }
                if (isValid[2] == false)
                {
                    Console.Write("Введите высоту бруска: \t");
                    if (!IsValidInput(out L))
                        continue;
                    isValid[2] = true;
                }
                if (isValid[3] == false)
                {
                    Console.Write("Введите длину цилиндра:\t");
                    if (!IsValidInput(out l))
                        continue;
                    isValid[3] = true;
                }
                isValid[4] = true;
            }

            double r = Math.Min(Math.Min(a / 2, b / 2), L); // радиус не должен превышать половину размера ребер как и длины.
            double Vofbar = a * b * L;
            double Vofcylinder = Math.PI * Math.Pow(r, 2) * l;
            double pecentMat = (Vofbar - Vofcylinder) / Vofbar;

            Console.WriteLine("Объем бруска равен: " + Vofbar + " кубических единиц \t");
            Console.WriteLine("Объем цилиндра равен: " + Vofcylinder + " кубических единиц \t");
            Console.Write("Процент материала, ушедшего в отдходы равен: " + Math.Round(pecentMat * 100) + " %");
        }

        private static bool IsValidInput(out double value)
        {
            string input = Console.ReadLine();

            if (input.Contains(" "))
            {
                Console.WriteLine("Ошибка: пробелы вводить нельзя!!!!");
                value = 0.0;
                return false;
            }
           
            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                Console.WriteLine("Ошибка: введите число!!!!");
                return false;
            }

            if (value <= 0)
            {
                Console.WriteLine("Ошибка: число не должно быть отрицательным или равно 0!!!!");
                return false;
            }

            return true;
        }
    }
}

