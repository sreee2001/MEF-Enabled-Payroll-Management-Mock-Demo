using Interfaces.BusinessObjects;
using Interfaces.Entities;
using Models.BusinessObjects;
using System;
using System.ComponentModel.Composition;

namespace PhaseOneExtension
{
    [Export(typeof(IPayrollRegistration))]
    public class WalmartTexas : PayrollRegistration
    {
        public WalmartTexas() : base("Walmart", "Texas") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }

    [Export(typeof(IPayrollRegistration))]
    public class WalmartFlorida : PayrollRegistration
    {
        public WalmartFlorida() : base("Walmart", "Florida") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }

    [Export(typeof(IPayrollRegistration))]
    public class WalmartOhio : PayrollRegistration
    {
        public WalmartOhio() : base("Walmart", "Ohio") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
}
