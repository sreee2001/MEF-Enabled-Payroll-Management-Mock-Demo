using Interfaces.Entities;

namespace Interfaces.BusinessObjects
{
    // equivalent of IOperationData
    public interface IPayrollRegistration
    {
        ICompany RegisteredCompany { get; }
        IState RegisteredTaxState { get; }

        void ProcessPayroll();
    }
}