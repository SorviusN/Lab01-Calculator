using System;

namespace Lab01Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            try 
            {    
                StartSequence();
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

        public static void StartSequence() // initial startup.
        {
                Console.WriteLine("Please enter a number greater than zero (0).");
                int arrSize = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[arrSize];
                int[] populatedArr = Populate(arr, arrSize);
                int sum = GetSum(populatedArr);

                int product = GetProduct(arr, sum); // calling function

                decimal quotient = GetQuotient(product); // calling function

                // After this point data will only be printed and not expected. No more functions to call as well.
                Console.WriteLine($"Your array size is{arrSize}");

                Console.WriteLine("The numbers in the array are:");
                foreach (int item in arr) Console.WriteLine($"{item} ");

                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
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
            if (sum < 20) throw new Exception($"Value of {sum} is too low."); // Throws an error if given sum is too low.
            return sum;
        }

        public static int GetProduct(int[] arr, int sum) // Multipling the sum of the array by a specified value in the array.
        {
            Console.WriteLine($"Please enter a number between 1 and {arr.Length}.");

            int mult = Convert.ToInt32(Console.ReadLine());
            int product = (sum * arr[mult]);

            return product;
        }

        public static decimal GetQuotient(int product) // Dividing the multiplied number by an input value.
        {
            Console.WriteLine($"Please enter in a number to divide your product {product} by.");

            int divi = Convert.ToInt32(Console.ReadLine());
            if (divi == 0) throw new DivideByZeroException(); // Handle Divbyzero exception. Throw an error if the case is true.

            decimal quotient = Decimal.Divide(product, divi);
            return quotient;
        }
    }
}
