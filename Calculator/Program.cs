using System;

namespace Calculator
{
    class Program
    {
        private static string _ERROR_MSG_ = "One of the two inputs is not a number.";
        private static int _MAX_ATTEMPTS_ = 3;

        static void Main(string[] args)
        {
            bool notNumbers = true;
            int attemptsLeft = _MAX_ATTEMPTS_;
            float num1 = 0;
            float num2 = 0;

            while (notNumbers && attemptsLeft > 0)
            {
                Console.WriteLine("Please enter number:");
                bool isNum1 = float.TryParse(Console.ReadLine(), out num1);

                Console.WriteLine("Please enter another number:");
                bool isNum2 = float.TryParse(Console.ReadLine(), out num2);

                notNumbers = !isNum1 || !isNum2;
                if (notNumbers)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(_ERROR_MSG_);
                    Console.ResetColor();
                    attemptsLeft--;
                }
            }

            if (attemptsLeft == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You ran out of attempts.");
                Console.ResetColor();
                Console.WriteLine("Press enter to exit.");
                Console.Read();
                return;
            }

            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("Select the operation you wish to execute:");
                Console.WriteLine("1 - Sum");
                Console.WriteLine("2 - Subtract");
                Console.WriteLine("3 - Multiply");
                Console.WriteLine("4 - Divide");
                Console.WriteLine("0 - Exit");

                bool isNum = int.TryParse(Console.ReadLine(), out option);

                Console.Clear();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        break;
                    case 1:
                        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                        break;
                    case 2:
                        Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                        break;
                    case 3:
                        Console.WriteLine($"{num1} x {num2} = {num1 * num2}");
                        break;
                    case 4:
                        if (num2 != 0)
                        {
                            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                        }
                        else
                        {
                            Console.WriteLine("Division by zero is not possible.");
                        }
                        break;
                    default:
                        Console.WriteLine("You did not select an available option.");
                        break;
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            } while (option != 0);

            Environment.Exit(0);
        }
    }
}
