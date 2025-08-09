using Interfaces.BusinessObjects;
using Interfaces.Entities;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BusinessObjects
{
    public abstract class PayrollRegistration : IPayrollRegistration
    {
        public ICompany RegisteredCompany { get; private set; }
        public IState RegisteredTaxState { get; private set; }

        protected PayrollRegistration(string companyName, String stateName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
                throw new ArgumentNullException(nameof(companyName), "Company name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(stateName))
                throw new ArgumentNullException(nameof(stateName), "State name cannot be null or empty.");

            // TODO: Validate companyName and stateName against existing records if necessary.
            RegisteredCompany = new Company() { Name = companyName}; 
            RegisteredTaxState = new State() { Name = stateName };
        }

        public void ProcessPayroll()
        {
            Console.WriteLine($"Processing payroll for [{RegisteredCompany.Name}] in state [{RegisteredTaxState.Name}].");
            // Here you would implement the actual payroll processing logic.

            // This could involve calculating salaries, taxes, and other deductions,
            RunPayrollForCompany(RegisteredCompany, RegisteredTaxState);

            // updating records, and possibly generating reports or notifications.
            // For demonstration purposes, we'll just simulate some processing time.
            System.Threading.Thread.Sleep(1000); // Simulate processing time

            Console.WriteLine($"Payroll processed for [{RegisteredCompany.Name}] in state {RegisteredTaxState.Name}.");
        }

        public abstract void RunPayrollForCompany(ICompany company, IState state);
    }
}
