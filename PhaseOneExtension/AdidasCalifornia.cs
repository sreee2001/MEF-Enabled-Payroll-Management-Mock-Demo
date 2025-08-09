using Interfaces.BusinessObjects;
using Interfaces.Entities;
using Models.BusinessObjects;
using System;
using System.ComponentModel.Composition;

namespace PhaseOneExtension
{
    [Export(typeof(IPayrollRegistration))]
    public class AdidasCalifornia : PayrollRegistration
    {
        public AdidasCalifornia() : base("Adidas", "California") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }

    [Export(typeof(IPayrollRegistration))]
    public class AdidasTexas : PayrollRegistration
    {
        public AdidasTexas() : base("Adidas", "Texas") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }

    [Export(typeof(IPayrollRegistration))]
    public class AdidasUtah : PayrollRegistration
    {
        public AdidasUtah() : base("Adidas", "Utah") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
}
