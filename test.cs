using AnsiTools;


public class Testing
{
    public static void Test<T>(T expected, T actual, string description = "Test")
    {
        if (expected.Equals(actual))
        {
            Console.WriteLine($"{ANSICodes.Colors.Green} --PASSED--{description}.{ANSICodes.Colors.Yellow}Expected: {expected}, Actual: {actual}{ANSICodes.Reset}");
        }
        else
        {
            Console.WriteLine($"{ANSICodes.Colors.Red} --FAILED-- {description}.{ANSICodes.Colors.Yellow} Expected: {expected}, {ANSICodes.Colors.Red}Actual: {actual}{ANSICodes.Reset}");
        }
    }
}