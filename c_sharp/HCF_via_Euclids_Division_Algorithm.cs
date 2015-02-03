using System;

namespace Concepts
{
    public class Runner
    {
        static void Main()
        {
            int number1, number2;
            do
            {
                Console.WriteLine("\nEnter two numbers:\nNumber 1: ");
                number1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Number 2: ");
                number2 = int.Parse(Console.ReadLine());
                var hcf = (new HCF(number1, number2)).CalculateViaEuclidsDivisionAlgorithm();
                Console.WriteLine("HCF of {0} and {1}: {2}\n", number1, number2, hcf);
                Console.WriteLine("Enter both numbers less than or equal to zero to exit\n.");
            } while (number1 > 0 && number2 > 0);

        }
    }

    public class HCF
    {
        int Number1;
        int Number2;
        public HCF(int number1, int number2)
        {
            if (number1 < number2)
            {
                Number1 = number2;
                Number2 = number1;
            }
            else
            {
                Number1 = number1;
                Number2 = number2;
            }
        }

        public int CalculateViaEuclidsDivisionAlgorithm()
        {
            int a = Number1, b = Number2;
            if (a > 0 && b > 0)
            {
                int q = a / b;
                int r = a % b;
                while (r != 0 && r != 1)
                {
                    a = b;
                    b = r;
                    q = a / b;
                    r = a % b;
                }

                if (r == 0)
                    return b;
                else if (r == 1)
                    return 1;
            }
            return -1;
        }
    }
}