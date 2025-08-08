using System;

namespace ConsoleDemo
{
    static class Project
    {
        static void Main(string[] args)
        {
            DisplayIntro();
            Console.WriteLine();

            int selection = -1;

            while (selection != 0)
            {
                int totalOptions = ShowPayrollProcessingOptions();
                Console.WriteLine();

                selection = ReadSelection(totalOptions);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static int ReadSelection(int totalOptions)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int option) && option >= 0 && option <= totalOptions)
            {
                if (option == 0)
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return 0; // Exit option
                }
                Console.WriteLine($"You selected option {option}.");
                Console.WriteLine($"Processing payroll for option {option}...");
                // Simulate processing the payroll for the selected option.
                Console.WriteLine($"Payroll processed for option {option} successfully!");
                Console.WriteLine($"Press Enter to continue...");
                Console.ReadLine();
                // Here you would typically call a method to process the payroll based on the selected option.
                return option;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please run the program again and select a valid option.");
                Console.WriteLine($"Press Enter to continue...");
                Console.ReadLine();
                return -1; // Indicating an invalid selection
            }
        }

        private static int ShowPayrollProcessingOptions()
        {
            Console.Clear();
            //Console.WriteLine("==========================================================");
            Console.WriteLine($"What do you want to do:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"[0]. Quit!");
            Console.WriteLine($"[1]. Process Payroll for everyone!");

            int startIndex = 2;

            int NumberOfCompaniesRegistered = 2;
            string[] companies = new string[NumberOfCompaniesRegistered];
            companies[0] = "Company_Name A";
            companies[1] = "Company_Name B";
            string[][] companyTaxStates = new string[NumberOfCompaniesRegistered][];
            companyTaxStates[0] = new string[] { "State_Name A", "State_Name B" };
            companyTaxStates[1] = new string[] { "State_Name B", "State_Name C", "State_Name D" };

            Console.WriteLine();
            for (int i = 0; i < NumberOfCompaniesRegistered; i++)
            {
                Console.WriteLine($"[{startIndex}]. Process Payroll for Company : [{companies[i]}] in all registered States!");
                startIndex++;
                for (int j = 0; j < companyTaxStates[i].Length; j++)
                {
                    Console.WriteLine($"[{startIndex}]. Process Payroll for Company : [{companies[i]}] in [{companyTaxStates[i][j]}]!");
                    startIndex++;
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Please select an option from above and press Enter to continue.");

            var totalOptions = startIndex - 1;

            return totalOptions;
        }

        private static void DisplayIntro()
        {
            Console.WriteLine($"Welcome to Payroll Management Service Demo!{Environment.NewLine}");
            Console.WriteLine($"It uses C# 7.3 and targets .NET Framework 4.7.2.{Environment.NewLine}");
            Console.WriteLine($"I am using MEF to show case how a project and application can be expanded without changing released code and only adding additional compiled projects at runtime into a targeted directory.{Environment.NewLine}");

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
