using static ConsoleApp3.Program;

namespace ConsoleApp3
{
    public class Calculation
    {
        /// <summary>
        /// Расчет квадратного уравнения.
        /// </summary>
        /// <exception cref="DiscriminantException"></exception>
        internal static void EquationCalculation(int a, int b, int c, Dictionary<string, string> data, ref bool isException)
        {
            int discriminant = 0;
            double x1, x2;
            string message;
            if ((a != 0) & (b != 0) & (c != 0))
            {
                try
                {
                    discriminant = (int)Math.Pow(b, 2) - 4 * a * c;
                    if (discriminant > 0)
                    {
                        x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                        Console.WriteLine($"x1= {x1}, x2= {x2}");
                    }
                    else if (discriminant == 0)
                    {
                        x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        Console.WriteLine($"x= {x1}");
                    }
                    else
                    {
                        throw new DiscriminantException("Вещественных значений не найдено, дискриминант меньше 0");
                    }
                }
                catch (DiscriminantException exp)
                {
                    string d = discriminant.ToString();
                    message = exp.Message;
                    data.Add("D=", d);
                    FormatData(Severity.Warning, message, data);
                    isException = true;
                }
            }
            else
            {
                isException = true;
                throw new DiscriminantException("Вещественных значений нет, т.к. неверно введены данные");
            }
        }
    }
}
