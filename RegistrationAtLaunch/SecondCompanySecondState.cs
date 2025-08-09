using Interfaces.BusinessObjects;
using Interfaces.Entities;
using Models.BusinessObjects;
using System;
using System.ComponentModel.Composition;

namespace RegistrationAtLaunch
{
    [Export(typeof(IPayrollRegistration))]
    public class SecondCompanySecondState : PayrollRegistration
    {
        public SecondCompanySecondState() : base("Second Company", "Second State") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
}
