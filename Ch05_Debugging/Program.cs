using static System.Console;


namespace Ch05_Debugging
{
    class Program
    {
        static double Add(double a, double b)
        {
            return a + b; //deliberate bug here

        }


        static void Main(string[] args)
        {
            double a = 4.5;
            double b = 2.5;
            double answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine();
        }
    }
}
