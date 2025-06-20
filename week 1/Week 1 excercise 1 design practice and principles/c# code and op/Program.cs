using System;

class SingletonMathExample
{
    class MathLogger
    {
        private static MathLogger instance;

        private MathLogger()
        {
            Console.WriteLine("MathLogger instance created.");
        }

        public static MathLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MathLogger();
            }
            return instance;
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine("[ADD] " + a + " + " + b + " = " + result);
            Log("Performed addition");
            return result;
        }

        public int Multiply(int a, int b)
        {
            int result = a * b;
            Console.WriteLine("[MULTIPLY] " + a + " * " + b + " = " + result);
            Log("Performed multiplication");
            return result;
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG]: " + message);
            Console.WriteLine("Logger instance hash: " + this.GetHashCode());
        }
    }

    static void Main()
    {
        var logger = MathLogger.GetInstance();

        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());

        Console.Write("Enter operation (add/multiply): ");
        string op = Console.ReadLine().ToLower();

        switch (op)
        {
            case "add":
                logger.Add(num1, num2);
                break;
            case "multiply":
                logger.Multiply(num1, num2);
                break;
            default:
                logger.Log("Invalid operation.");
                break;
        }

        Console.WriteLine("Logger used: " + logger.GetHashCode());
    }
}
