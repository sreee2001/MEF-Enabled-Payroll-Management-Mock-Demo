using System;

namespace ConsoleDemo
{
    static class Project
    {
        static void Main(string[] args)
        {
            var payrollProcessing = new ConsolePayrollProcessing();

            payrollProcessing.DisplayIntro();
            Console.WriteLine();

            int selection = -1;

            while (selection != 0)
            {
                int totalOptions = payrollProcessing.ShowPayrollProcessingOptions();
                Console.WriteLine();

                selection = payrollProcessing.ReadSelection(totalOptions);

                if (payrollProcessing.IsValidSelection(selection, totalOptions))
                {
                    if (selection == 0)
                    {
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    }
                    payrollProcessing.ProcessSelection(selection);

                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    Console.WriteLine($"Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();
            }

            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
        }

    }
}
