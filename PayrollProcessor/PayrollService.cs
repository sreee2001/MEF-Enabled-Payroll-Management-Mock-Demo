using Interfaces.BusinessObjects;
using Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProcessor
{
    [Export(typeof(IPayrollService))]
    public class PayrollService : IPayrollService
    {
        [ImportMany]
        public IEnumerable<IPayrollRegistration> AllRegistrations { get; set; }

        public IEnumerable<IPayrollRegistration> GetAllRegistrations()
        {
            return AllRegistrations;
        }

        public void ProcessPayrollForALL()
        {
            Console.WriteLine("Initialing payroll for all registered companies and states...");
            Console.WriteLine();

            foreach (var registration in AllRegistrations)
            {
                Console.WriteLine("************");
                if (registration.RegisteredCompany != null && registration.RegisteredTaxState != null)
                {
                    //Console.WriteLine($"Running payroll for [{registration.RegisteredCompany.Name}] in [state {registration.RegisteredTaxState.Name}].");
                    registration.ProcessPayroll();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Registration is missing company or state information.");
                }
            }
            Console.WriteLine("Finished payroll processing .");
            Console.WriteLine();
        }

        public void ProcessPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Initiating payroll for {company.Name} in state {state.Name}...");
            var registration = AllRegistrations.FirstOrDefault(r => r.RegisteredCompany?.Name == company.Name && r.RegisteredTaxState?.Name == state.Name);
            if (registration != null)
            {
                registration.ProcessPayroll();
            }
            else
            {
                Console.WriteLine($"No payroll registration found for {company.Name} in state {state.Name}.");
            }
            Console.WriteLine($"Finished processing for {company.Name} in state {state.Name}.");
        }
    }
}
