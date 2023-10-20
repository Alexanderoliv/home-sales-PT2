using System;

public class Program
{
    private static readonly string[] SalespeopleNames = { "Danielle", "Edward", "Francis" };
    private static readonly char[] SalespeopleInitials = { 'D', 'E', 'F' };
    private static readonly double[] SalesValues = new double[3];

    public static void Main(string[] args)
    {
        char salesperson;
        double saleAmount;

        Console.WriteLine("Enter salesperson initial (D, E, F) or Z to quit:");
        salesperson = Char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();  // For new line

        while (salesperson != 'Z')
        {
            int index = Array.IndexOf(SalespeopleInitials, salesperson);
            if (index != -1)
            {
                bool isValidNumber;
                do
                {
                    Console.WriteLine("Enter sale amount:");
                    string input = Console.ReadLine();
                    isValidNumber = double.TryParse(input, out saleAmount);
                    if (!isValidNumber)
                    {
                        Console.WriteLine("Error: Invalid sale amount entered. Please enter a valid number.");
                    }
                } while (!isValidNumber);

                SalesValues[index] += saleAmount;
            }
            else
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again.");
            }

            Console.WriteLine("\nEnter salesperson initial (D, E, F) or Z to quit:");
            salesperson = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();  // For new line
        }

        DisplayResults();
    }

    public static void DisplayResults()
    {
        double grandTotal = 0;
        for (int i = 0; i < SalesValues.Length; i++)
        {
            grandTotal += SalesValues[i];
        }

        for (int i = 0; i < SalespeopleInitials.Length; i++)
        {
            Console.WriteLine($"{SalespeopleNames[i]} ({SalespeopleInitials[i]}) Sales: ${SalesValues[i]:N2}");
        }
        Console.WriteLine($"\nGrand Total: ${grandTotal:N2}");

        int highestIndex = Array.IndexOf(SalesValues, Math.Max(SalesValues[0], Math.Max(SalesValues[1], SalesValues[2])));
        Console.WriteLine($"Highest Sale: {SalespeopleInitials[highestIndex]}");
    }
}
