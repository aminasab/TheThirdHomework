using System.Text;

internal class PrintPoints
{
    static int origRow;
    static int origCol;
    static int selectedValue = 0;
    static string[] strings = new string[3] { "a:", "b:", "c:" };
    public static string[] variables = new string[3] { "a", "+b", "+c" };
    static string[] introducedVariables = new string[3] { "", "", "" };
    static ConsoleKeyInfo ki;
    static StringBuilder[] stringBuilders = new StringBuilder[3];

    public static void CreateStringBuilders()
    {
        for (int i = 0; i < 3; i++)
        {
            stringBuilders[i] = new StringBuilder();
        }
    }

    /// <summary>
    /// Метод, который перезаписывает массивы.
    /// </summary>
    private static void ArrayOverwriting()
    {
        introducedVariables[selectedValue] = stringBuilders[selectedValue].ToString();
        variables[selectedValue] = stringBuilders[selectedValue].ToString();
    }

    /// <summary>
    /// Вывод уравнения и его переменных на консоль. 
    /// </summary>
    public static void Print()
    {
        origRow = Console.CursorTop;
        origCol = Console.CursorLeft;
        do
        {
            PrintMenu();
            WriteAt(5, selectedValue + 1);
            switch (ki.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedValue > 0)
                        selectedValue--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedValue < strings.Length - 1)
                    {
                        selectedValue++;
                    }
                    break;
            }
            Console.Clear();
        } while (ki.Key != ConsoleKey.Enter);
        string line = new string('-', 50);
        Console.WriteLine(line);
    }

    /// <summary>
    /// Вывести меню.
    /// </summary>
    private static void PrintMenu()
    {
        if (selectedValue < 2) Console.WriteLine($"{variables[0]}*x^2+b*x+c=0");
        else
        {
            if (variables[1].Contains('-'))
            {
                Console.WriteLine($"{variables[0]}*x^2{variables[1]}*x+c=0");
            }
            else
            {
                Console.WriteLine($"{variables[0]}*x^2+{variables[1]}*x+c=0");
            }
        }
        for (var i = 0; i < strings.Length; i++)
        {
            Console.WriteLine($"{(selectedValue == i ? ">" : " ")} {strings[i]} {introducedVariables[i]}");
        }
    }

    /// <summary>
    /// Метод, принимающий координаты для введения переменной.
    /// </summary>
    protected static void WriteAt(int x, int y)
    {
        try
        {
            Console.SetCursorPosition(origCol + x, origRow + y);
            do
            {
                ki = Console.ReadKey();
                if (ki.Key != ConsoleKey.DownArrow & ki.Key != ConsoleKey.UpArrow & ki.Key != ConsoleKey.Enter & ki.Key != ConsoleKey.Delete)
                {
                    stringBuilders[selectedValue].Append(ki.KeyChar.ToString());
                    ArrayOverwriting();
                }
                else if (ki.Key == ConsoleKey.Delete)
                {
                    stringBuilders[selectedValue].Remove(0, stringBuilders[selectedValue].Length);
                    ArrayOverwriting();
                    Console.Clear();
                    PrintMenu();
                }
            } while (ki.Key != ConsoleKey.DownArrow & ki.Key != ConsoleKey.UpArrow & ki.Key != ConsoleKey.Enter & ki.Key != ConsoleKey.Delete);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
}




