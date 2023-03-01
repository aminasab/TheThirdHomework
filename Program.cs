using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program : PrintPoints
    {
        public enum Severity
        {
            Warning,
            Error,
            Fatal
        }
        static void Main(string[] args)
        {
            bool isException = false;
            string message = " ";
            Dictionary<string, string> data = new Dictionary<string, string>();
            string outputOfError = "Вы неправильно ввели переменную";
            int a = 0, b = 0, c = 0;
            Print();
            try
            {
                try
                {
                    a = int.Parse(introducedVariables[0]);
                }
                catch (OverflowException exp)
                {
                    message = exp.Message;
                    data.Add("aOverflow", introducedVariables[0]);
                    FormatData(Severity.Fatal, message, data);
                }
                catch (Exception aException)
                {
                    Console.WriteLine(outputOfError + " a");
                    message = aException.Message;
                    data.Add("a", introducedVariables[0]);
                    FormatData(Severity.Error, message, data);
                }

                try
                {
                    b = int.Parse(introducedVariables[1]);
                }
                catch (OverflowException exp)
                {
                    message = exp.Message;
                    data.Add("bOverflow", introducedVariables[1]);
                    FormatData(Severity.Fatal, message, data);
                }
                catch (Exception bException)
                {
                    Console.WriteLine(outputOfError + " b");
                    message = bException.Message;
                    data.Add("b", introducedVariables[1]);
                    FormatData(Severity.Error, message, data);
                }

                try
                {
                    c = int.Parse(introducedVariables[2]);
                }
                catch (OverflowException exp)
                {
                    message = exp.Message;
                    data.Add("cOverflow", introducedVariables[2]);
                    FormatData(Severity.Fatal, message, data);
                }
                catch (Exception cException)
                {
                    Console.WriteLine(outputOfError + " c");
                    message = cException.Message;
                    data.Add("c", introducedVariables[2]);
                    FormatData(Severity.Error, message, data);
                }
                finally
                {
                    Calculation.EquationCalculation(a, b, c, data, ref isException);
                    if (isException == true) throw new DiscriminantException("Ошибка вычисления");
                }
            }
            catch (DiscriminantException exp)
            {
                message = exp.Message;
                data.Add("DiscriminantException", "ошибка");
                FormatData(Severity.Error, message, data);
            }
        }
        // Создание переменных для счетчиков в методе: FormatData.
        static int i = 0;
        static int j = 0;

        /// <summary>
        /// Метод для вывода ошибок, предупреждений.
        /// </summary>
        internal static void FormatData(Severity severity, string message, Dictionary<string, string> data)
        {
            string[] variables = new string[] { "a", "b", "c" };
            string[] mistakes = new string[] { "aOverflow", "bOverflow", "cOverflow" };
            switch (severity)
            {
                case Severity.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                    if ((i < 3) && (data.ContainsKey(variables[i])))
                    {
                        Console.WriteLine(variables[i] + "=" + data[variables[i]]);
                    }
                    i++;
                    Console.ResetColor();
                    break;

                case Severity.Warning:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(message);
                    Console.WriteLine("Дискриминант = " + data["D="]);
                    Console.ResetColor();
                    break;

                case Severity.Fatal:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    if ((j < 3) && data.ContainsKey(mistakes[j]))
                    {
                        Console.WriteLine($"Вы ввели {data[mistakes[j]]}");
                    }
                    j++;
                    Console.WriteLine("Введите число в пределах от " + int.MinValue + " до " + int.MaxValue);
                    Console.ResetColor();
                    break;
            }
        }
    }
}
