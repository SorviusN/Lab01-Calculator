using System;

namespace Lab01Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            StartSequence();
        }

        public static void StartSequence()
        {
            try
            {
                Console.WriteLine("Please enter a number greater than zero (0).");
                int arrSize = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[arrSize];
                int[] populatedArr = Populate(arr, arrSize);
                int sum = GetSum(populatedArr);

                int mult = 0; // initializing the multiplier to be used in the function.
                int product = GetProduct(arr, sum, mult);

                int divi = 1; //initializing the divisor to be used in the function.
                decimal quotient = GetQuotient(product, divi);

                Console.WriteLine($"Your array size is{arrSize}");

                Console.WriteLine("The numbers in the array are:");
                foreach (int item in arr) Console.WriteLine($"{item} ");

                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {mult} = {product}");
                Console.WriteLine($"{product} / {divi} = {quotient}");
            }
            catch( Exception e) 
            {
                Console.WriteLine($"Something went wrong ({e}), please try again!");
            }
            finally
            {
                Console.WriteLine("Program terminated.");
            }
        }

        public static int[] Populate(int[] arr, int size) // filling in each value by prompting the user for input.
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Please enter a number: {i + 1} of {size}");
                int num = Convert.ToInt32(Console.ReadLine());
                arr[i] = num;
            }
            return arr;
        }

        public static int GetSum(int[] arr) //adding up all numbers in the arr.
        {
            int sum = 0;
            foreach (int val in arr)
            {
                sum += val;
            }
            if (sum < 20) throw new Exception($"Value of {sum} is too low.");
            return sum;
        }

        public static int GetProduct(int[] arr, int sum, int mult)
        {
            Console.WriteLine($"Please enter a number between 1 and {arr.Length}.");

            mult = Convert.ToInt32(Console.ReadLine());
            if (mult > arr.Length || mult < 1) throw new IndexOutOfRangeException();
            int product = (sum * arr[mult]);

            return product;
        }

        public static decimal GetQuotient(int product, int divi)
        {
            Console.WriteLine($"Please enter in a number to divide your product {product} by.");

            divi = Convert.ToInt32(Console.ReadLine());
            if (divi == 0) throw new DivideByZeroException();

            decimal quotient = Decimal.Divide(product, divi);
            return quotient;
        }
    }
}
