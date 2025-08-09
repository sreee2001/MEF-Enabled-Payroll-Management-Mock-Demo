using Interfaces.BusinessObjects;
using Interfaces.Entities;
using System.Collections.Generic;

namespace PayrollProcessor
{
    // equivalent of IOperation
    public interface IPayrollService
    {
        // Define methods that the PayrollService should implement
        void ProcessPayrollForALL();
        void ProcessPayrollForCompany(ICompany company, IState state);

        IEnumerable<IPayrollRegistration> GetAllRegistrations();
    }

}
