using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Expression_Evaluator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Console.WriteLine("Enter 10 integers:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Number {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer:");
                }
            }
            Console.Write("\nEnter your formula (use 'x' as variable, e.g., (2*x + 3) % 5): ");
            string formula = Console.ReadLine();

            try
            {
                // Apply formula to each number
                int[] evaluated = numbers.Select(x => EvaluateExpression(x, formula)).ToArray();

                // Display results
                Console.WriteLine("\nResults:");
                Console.WriteLine($"{"Original",-15} {"Evaluated",-15}");
                Console.WriteLine(new string('-', 30));

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine($"{numbers[i],-15} {evaluated[i],-15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating formula: {ex.Message}");
            }
        }
        static int EvaluateExpression(int x, string formula)
        {
            // Replace 'x' with the current number
            string expression = formula.Replace("x", x.ToString());

            // Use DataTable.Compute for safe evaluation
            var result = new DataTable().Compute(expression, null);

            return Convert.ToInt32(result);
        }
    }
}
