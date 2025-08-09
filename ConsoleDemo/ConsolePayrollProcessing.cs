using Interfaces.BusinessObjects;
using PayrollProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace ConsoleDemo
{
    /*
 * 
 * Notes
 ********************************************************************** 
 *
 * Interface.Dll
 * 
 * Entities:
 *      ICountry
 *      IState
 * Registration:
 *      IPayrollRegistration
 *          ICountry
 *          IState
 *          ProcessPayroll()
 *  PayrollService:
 *      IPayrollService
 *          ProcessPayrollForALL()
 *          ProcessPayrollForCompany(ICompany company, IState state)
 *          
 ********************************************************************** 
 *
 *  Models.Dll:
 *  
 *  Entities:
 *      Country : ICountry
 *      State : IState
 *  Registration:
 *      PayrollRegistration : IPayrollRegistration
 *          abstract class ProcessPayroll()
 *      
 ********************************************************************** 
 *  
 *  PayrollProcessor.Dll:
 *  
 *  Processing:
 *      PayrollService : IPayrollService
 *          List<IPayrollRegistration> AllRegistrations
 *          ProcessPayrollForALL()
 *          ProcessPayrollForCompany(ICompany company, IState state)
 *  
 *  Registration:
 *      FirstCompanyFirstStateRegistration : PayrollRegistration
 *          Implementation of ProcessPayroll()
 *      FirstCompanySecondStateRegistration : PayrollRegistration
 *          Implementation of ProcessPayroll()
 *      FirstCompanyThirdStateRegistration : PayrollRegistration
 *          Implementation of ProcessPayroll()
 *      SecondCompanyFirstStateRegistration : PayrollRegistration
 *          Implementation of ProcessPayroll()
 *  
 ********************************************************************** 
 *
 *
 *
 *  
*/

    public class ConsolePayrollProcessing
    {
        [Import]
        public IPayrollService PayrollService { get; set; }

        private Dictionary<int, IPayrollRegistration> _registrationMap = new Dictionary<int, IPayrollRegistration>();

        public ConsolePayrollProcessing()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            // Add the current assembly to the catalog
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ConsolePayrollProcessing).Assembly));

            // Add any additional assemblies or directories to the catalog
            // For example, if you have other assemblies in a specified directory (currentDirectory):
            catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory));

            // Create a CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);
            
            // Compose the parts (this will automatically import any dependencies)
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine($"Error during composition: {compositionException.Message}");
            }
        }

        public void DisplayIntro()
        {
            Console.WriteLine($"Welcome to Payroll Management Service Demo!{Environment.NewLine}");
            Console.WriteLine($"It uses C# 7.3 and targets .NET Framework 4.7.2.{Environment.NewLine}");
            Console.WriteLine($"I am using MEF to show case how a project and application can be expanded without changing released code and only adding additional compiled projects at runtime into a targeted directory.{Environment.NewLine}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public int ShowPayrollProcessingOptions()
        {
            Console.Clear();
            //Console.WriteLine("==========================================================");
            Console.WriteLine($"What do you want to do:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"[0]. Quit!");
            Console.WriteLine($"[1]. Process Payroll for everyone!");

            int startIndex = 2;

            var allRegistrations = PayrollService.GetAllRegistrations().ToList();

            Console.WriteLine();

            for (int i = 0; i < allRegistrations.Count; i++)
            {
                var registration = allRegistrations[i];
                var company = registration.RegisteredCompany;
                var state = registration.RegisteredTaxState;

                // store startIndex and registration details in a dictionary or list if needed
                _registrationMap[startIndex] = registration;

                Console.WriteLine($"[{startIndex}]. Process Payroll for Company : [{company.Name}] in {state.Name}!");
                startIndex++;
                Console.WriteLine();
            }

            Console.WriteLine($"Please select an option from above and press Enter to continue.");

            var totalOptions = startIndex - 1;

            return totalOptions;
        }

        public int ReadSelection(int totalOptions)
        {
            string input = Console.ReadLine();

            int.TryParse(input, out int option);
            return option;
        }

        public bool IsValidSelection(int selection, int totalOptions)
        {
            return selection >= 0 && selection <= totalOptions;
        }

        internal void ProcessSelection(int selection)
        {
            if (selection == 0)
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                return ; // Exit option
            }
            Console.WriteLine($"You selected option {selection}.");
            Console.WriteLine();
            Console.WriteLine($"Initiating payroll Service for option {selection}...");
            Console.WriteLine();

            if (selection == 1)
            {
                // Process payroll for all registered companies and states
                PayrollService.ProcessPayrollForALL();
                Console.WriteLine($"Payroll processed for all registered companies and states successfully!");
                Console.WriteLine();
                Console.WriteLine($"Press any key to continue...");
                Console.ReadKey();
                return; // Indicating successful processing for all
            }
            else
            {
                _registrationMap.TryGetValue(selection, out IPayrollRegistration registration);
                if (registration == null)
                {
                    Console.WriteLine($"No registration found for option {selection}. Please run the program again and select a valid option.");
                    Console.WriteLine($"Press any key to continue...");
                    Console.ReadKey();
                    return; // Indicating an invalid selection
                }
                // Process the payroll for the selected registration
                PayrollService.ProcessPayrollForCompany(registration.RegisteredCompany, registration.RegisteredTaxState);

                Console.WriteLine($"Payroll processed for option {selection} successfully!");
                Console.WriteLine($"Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
