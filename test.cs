public class Testing
{
    public static void Test<T>(T expected, T actual, string description = "Test")
    {
        if (expected.Equals(actual))
        {
            Console.WriteLine($"{Colors.Green} --PASSED--{description}.{Colors.Yellow}Expected: {expected}, Actual: {actual}{ANSICodes.Reset}");
        }
        else
        {
            Console.WriteLine($"{Colors.Red} --FAILED-- {description}.{Colors.Yellow} Expected: {expected}, {Colors.Red}Actual: {actual}{ANSICodes.Reset}");
        }
    }
}