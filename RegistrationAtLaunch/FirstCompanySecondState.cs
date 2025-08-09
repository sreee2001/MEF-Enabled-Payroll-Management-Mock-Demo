using Interfaces.BusinessObjects;
using Interfaces.Entities;
using Models.BusinessObjects;
using System;
using System.ComponentModel.Composition;

namespace RegistrationAtLaunch
{
    [Export(typeof(IPayrollRegistration))]
    public class FirstCompanySecondState : PayrollRegistration
    {
        public FirstCompanySecondState() : base("First Company", "Second State") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
}
