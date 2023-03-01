internal class PrintPoints
{
    protected static int origRow;
    protected static int origCol;
    private static int selectedValue = 0;
    static string[] strings = new string[] { "a:", "b:", "c:" };
    static string[] variables = new string[] { "a", "+b", "+c" };
    public static string[] introducedVariables = new string[] { "", "", "" };

    /// <summary>
    /// Вывод уравнения и его переменных на консоль. 
    /// </summary>
    public static void Print()
    {
        origRow = Console.CursorTop;
        origCol = Console.CursorLeft;
        ConsoleKeyInfo ki;
        do
        {
            PrintMenu();
            WriteAt(5, selectedValue + 1);
            ki = Console.ReadKey();
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
                Console.WriteLine($"{variables[0]}*x^2{variables[1]}*x{variables[2]}=0");
            }
            else
            {
                Console.WriteLine($"{variables[0]}*x^2+{variables[1]}*x{variables[2]}=0");
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
            variables[selectedValue] = Console.ReadLine();
            introducedVariables[selectedValue] = variables[selectedValue];
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
}




